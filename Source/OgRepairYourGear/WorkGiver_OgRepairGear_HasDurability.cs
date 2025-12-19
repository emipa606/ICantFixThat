using System.Reflection;
using HarmonyLib;
using ICantFixThat;
using Verse;

namespace ICantFixThat_OgRepairYourGear;

[HarmonyPatch]
public static class WorkGiver_OgRepairGear_HasDurability
{
    public static MethodBase TargetMethod()
    {
        return AccessTools.Method("OgRepairGear.WorkGiver_OgRepairGear:HasDurability");
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