using HarmonyLib;
using RimWorld;
using Verse;

namespace ICantFixThat;

[HarmonyPatch(typeof(TargetingParameters), nameof(TargetingParameters.ForRepair), typeof(Pawn))]
public static class TargetingParameters_ForRepair
{
    public static void Postfix(ref TargetingParameters __result, Pawn repairer)
    {
        __result.validator = targ =>
            targ.HasThing && RepairUtility.PawnCanRepairEver(repairer, targ.Thing) && Main.CanRepair(targ.Thing);
    }
}