using System.Reflection;
using HarmonyLib;
using Verse;
using Verse.AI;

namespace ICantFixThat;

[HarmonyPatch]
public static class RepairUtility_PawnCanRepairEver
{
    public static MethodBase TargetMethod()
    {
        return AccessTools.Method("MoonyRepair.RepairUtility:PawnCanRepairEver");
    }

    public static void Postfix(ref bool __result, Thing t)
    {
        if (!__result)
        {
            return;
        }

        __result = Main.CanRepair(t);

        if (!__result)
        {
            JobFailReason.Is("ICFT.NoKnowledge.reason".Translate());
        }
    }
}