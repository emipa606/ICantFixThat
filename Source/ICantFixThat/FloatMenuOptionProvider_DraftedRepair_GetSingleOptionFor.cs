using HarmonyLib;
using RimWorld;
using Verse;

namespace ICantFixThat;

[HarmonyPatch(typeof(FloatMenuOptionProvider_DraftedRepair), "GetSingleOptionFor")]
public static class FloatMenuOptionProvider_DraftedRepair_GetSingleOptionFor
{
    public static void Postfix(ref FloatMenuOption __result, Thing clickedThing)
    {
        if (__result == null)
        {
            return;
        }

        if (Main.CanRepair(clickedThing))
        {
            return;
        }

        __result = new FloatMenuOption(
            "CannotRepair".Translate(clickedThing) + ": " + "ICFT.NoKnowledge.reason".Translate(), null);
    }
}