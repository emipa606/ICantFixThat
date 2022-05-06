using System.Reflection;
using HarmonyLib;
using ICantFixThat;
using Verse;
using Verse.AI;

namespace ICantFixThat_LTSMaintenance;

[HarmonyPatch]
public static class WorkGiver_DoApparelsMaintenance_HasJobOnThing
{
    public static MethodBase TargetMethod()
    {
        return AccessTools.Method("Maintenance.WorkGivers.WorkGiver_DoApparelsMaintenance:HasJobOnThing",
            new[] { typeof(Pawn), typeof(Thing), typeof(bool) });
    }

    public static void Postfix(ref bool __result, Pawn pawn, bool forced)
    {
        if (!__result)
        {
            return;
        }

        if (!pawn.Faction.IsPlayer)
        {
            return;
        }

        if (pawn.apparel.WornApparel.Any(apparel =>
                apparel.def.useHitPoints && apparel.HitPoints < (float)apparel.MaxHitPoints &&
                Main.CanRepair(apparel)))
        {
            return;
        }

        JobFailReason.Is("ICFT.NoKnowledge.reason".Translate());
        __result = false;
    }
}