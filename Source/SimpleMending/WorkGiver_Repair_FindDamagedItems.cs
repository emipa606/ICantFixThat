using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using ICantFixThat;
using Verse;
using Verse.AI;

namespace ICantFixThat_SimpleMending;

[HarmonyPatch]
public static class RepairUtilities_CanRepairThing
{
    public static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method("ComfyCuddlesWithEuterpe.RepairUtilities:CanRepairThing");
        yield return AccessTools.Method("ComfyCuddlesWithEuterpe.RepairUtilities:IsRepairCostAllowed");
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