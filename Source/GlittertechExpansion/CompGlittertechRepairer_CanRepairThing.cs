using System.Reflection;
using HarmonyLib;
using ICantFixThat;
using Verse;
using Verse.AI;

namespace ICantFixThat_GlittertechExpansion;

[HarmonyPatch]
public static class CompGlittertechRepairer_CanRepairThing
{
    public static MethodBase TargetMethod()
    {
        return AccessTools.Method("USH_GE.CompGlittertechRepairer:CanRepairThing",
            [typeof(Thing)]);
    }

    public static void Postfix(ref bool __result, Thing t)
    {
        if (!__result)
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