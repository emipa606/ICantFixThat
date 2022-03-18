using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace ICantFixThat;

[HarmonyPatch(typeof(WorkGiver_Repair), "HasJobOnThing", typeof(Pawn), typeof(Thing), typeof(bool))]
public static class WorkGiver_Repair_HasJobOnThing
{
    public static void Postfix(ref bool __result, Pawn pawn, Thing t)
    {
        if (!__result)
        {
            return;
        }

        if (!pawn.Faction.IsPlayer)
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