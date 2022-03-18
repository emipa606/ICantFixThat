using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using ICantFixThat;
using RimWorld;
using Verse;

namespace ICantFixThat_RepairWorkbench;

[HarmonyPatch]
public static class WorkGiver_Repair_FindDamagedItems
{
    public static MethodBase TargetMethod()
    {
        return AccessTools.Method("Repair.WorkGiver_Repair:FindDamagedItems",
            new[] { typeof(Pawn), typeof(Thing), typeof(Bill) });
    }

    public static void Postfix(ref List<Thing> __result)
    {
        if (__result == null || !__result.Any())
        {
            return;
        }

        var newList = __result.Where(Main.CanRepair).ToList();
        __result = newList;
    }
}