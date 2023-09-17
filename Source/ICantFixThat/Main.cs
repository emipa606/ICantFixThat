using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ICantFixThat;

[StaticConstructorOnStartup]
public static class Main
{
    private static readonly Dictionary<ThingDef, List<ResearchProjectDef>> thingResearchDictionary;

    static Main()
    {
        thingResearchDictionary = new Dictionary<ThingDef, List<ResearchProjectDef>>();
        foreach (var recipeDef in DefDatabase<RecipeDef>.AllDefs)
        {
            var thing = recipeDef.ProducedThingDef;
            if (thing == null)
            {
                continue;
            }

            var techRequired = getLowestResearchProjectDefs(recipeDef);
            if (techRequired == null)
            {
                continue;
            }

            thingResearchDictionary[thing] = techRequired;
        }

        Log.Message($"[ICantFixThat]: Cached the required research for {thingResearchDictionary.Count} things");

        new Harmony("Mlie.ICantFixThat").PatchAll(Assembly.GetExecutingAssembly());
    }

    public static bool CanRepair(Thing thing)
    {
        return CanRepair(thing.def);
    }

    public static List<ThingDef> GetDisallowedThings()
    {
        return thingResearchDictionary.Keys.Where(def => !CanRepair(def)).ToList();
    }

    public static bool CanRepair(ThingDef thingDef)
    {
        if (DebugSettings.godMode)
        {
            return true;
        }

        if (thingResearchDictionary.TryGetValue(thingDef, out var value))
        {
            if (value.Any(def => !def.IsFinished))
            {
                return false;
            }
        }

        if (ICantFixThatMod.instance.Settings.AlsoBlockTechlevel &&
            (int)Faction.OfPlayer.def.techLevel + ICantFixThatMod.instance.Settings.AlsoBlockTechlevelLevel <
            (int)thingDef.techLevel)
        {
            return false;
        }

        if (thingDef.building == null)
        {
            return true;
        }

        var entDef = thingDef as BuildableDef;
        if (entDef.minTechLevelToBuild != TechLevel.Undefined &&
            Faction.OfPlayer.def.techLevel < entDef.minTechLevelToBuild)
        {
            return false;
        }

        if (entDef.maxTechLevelToBuild != TechLevel.Undefined &&
            Faction.OfPlayer.def.techLevel > entDef.maxTechLevelToBuild)
        {
            return false;
        }

        return entDef.IsResearchFinished && Find.Storyteller.difficulty.AllowedToBuild(entDef);
    }

    private static List<ResearchProjectDef> getLowestResearchProjectDefs(RecipeDef recipe)
    {
        if (recipe.researchPrerequisite != null)
        {
            return new List<ResearchProjectDef> { recipe.researchPrerequisite };
        }

        if (recipe.researchPrerequisites is { Count: > 0 })
        {
            return recipe.researchPrerequisites;
        }

        if (recipe.recipeUsers == null)
        {
            return null;
        }

        var lowestTech = TechLevel.Archotech;
        ThingDef bestThing = null;
        foreach (var user in recipe.recipeUsers)
        {
            if (user.researchPrerequisites is not { Count: > 0 })
            {
                continue;
            }

            var tech = lowestTech;
            var currentTech = user.researchPrerequisites.Where(def => def.techLevel > tech)
                .OrderBy(def => def.techLevel);
            if (!currentTech.Any())
            {
                continue;
            }

            bestThing = user;
            lowestTech = currentTech.First().techLevel;
        }

        return bestThing?.researchPrerequisites;
    }
}