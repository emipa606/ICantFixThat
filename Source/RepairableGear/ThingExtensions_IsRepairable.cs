using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using ICantFixThat;
using Verse;

namespace ICantFixThat_RepairableGear;

[HarmonyPatch]
public static class ThingExtensions_IsRepairable
{
    public static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method("RepairableGear.ThingExtensions:IsRepairable",
            new[] { typeof(Thing) });
        yield return AccessTools.Method("RepairableGear.ThingExtensions:CanBeMaintenanced",
            new[] { typeof(Thing) });
    }

    public static void Postfix(ref bool __result, Thing thing)
    {
        if (!__result)
        {
            return;
        }

        __result = Main.CanRepair(thing);
    }
}