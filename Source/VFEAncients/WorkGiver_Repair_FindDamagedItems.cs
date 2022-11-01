using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using ICantFixThat;
using Verse;
using Verse.AI;
using VFEAncients;

namespace ICantFixThat_VFEAncients;

[HarmonyPatch]
public static class WorkGiver_Repair_FindDamagedItems
{
    public static MethodBase TargetMethod()
    {
        return AccessTools.Method("VFEAncients.HarmonyPatches.MendingPatches:RepairItem");
    }

    public static bool Prefix(ref bool __result, List<Thing> ingredients, RecipeDef recipeDef)
    {
        if (!recipeDef.HasModExtension<RecipeExtension_Mend>())
        {
            return true;
        }

        var thingToRepair = ingredients.FirstOrDefault(t =>
            t.stackCount == 1 && (t.def.IsWeapon || t.def.IsApparel) && t.def.useHitPoints &&
            t.HitPoints < t.MaxHitPoints);

        if (thingToRepair == null)
        {
            return true;
        }

        if (Main.CanRepair(thingToRepair))
        {
            return true;
        }

        JobFailReason.Is("ICFT.NoKnowledge.reason".Translate());
        __result = false;
        return false;
    }
}