using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace ICantFixThat;

[HarmonyPatch(typeof(WorkGiver_FixBrokenDownBuilding), "HasJobOnThing", typeof(Pawn), typeof(Thing), typeof(bool))]
public static class WorkGiver_FixBrokenDownBuilding_HasJobOnThing
{
    public static void Postfix(ref bool __result, Pawn pawn, Thing t)
    {
        if (!__result)
        {
            return;
        }

        if (!Main.IsValidRepairer(pawn))
        {
            return;
        }

        if (Main.CanRepair(t))
        {
            return;
        }

        JobFailReason.Is("ICFT.NoKnowledge.reason".Translate());
        __result = false;
    }
}