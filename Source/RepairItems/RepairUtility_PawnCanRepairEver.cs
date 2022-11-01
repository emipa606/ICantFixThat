using System.Reflection;
using HarmonyLib;
using Verse;

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
    }
}