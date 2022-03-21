using System.Reflection;
using HarmonyLib;
using ICantFixThat;
using RimWorld;
using Verse;

namespace ICantFixThat_VFEAncients;

[HarmonyPatch]
public static class WorkGiver_Repair_FindDamagedItems
{
    public static MethodBase TargetMethod()
    {
        return AccessTools.Method("VFEAncients.HarmonyPatches.MendingPatches:ExtraVerificationCheck",
            new[] { typeof(Bill), typeof(Thing) });
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