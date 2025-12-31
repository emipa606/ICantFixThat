using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using ICantFixThat;
using Verse;
using Verse.AI;

namespace ICantFixThat_RepairableGear;

[HarmonyPatch]
public static class ThingExtensions_IsRepairable
{
    public static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method("RepairableGear.ThingExtensions:IsRepairable",
            [typeof(Thing)]);
        yield return AccessTools.Method("RepairableGear.ThingExtensions:CanBeMaintenanced",
            [typeof(Thing)]);
    }

    public static void Postfix(ref bool __result, Thing thing)
    {
        if (!__result)
        {
            return;
        }

        __result = Main.CanRepair(thing);

        if (!__result)
        {
            JobFailReason.Is("ICFT.NoKnowledge.reason".Translate());
        }
    }
}