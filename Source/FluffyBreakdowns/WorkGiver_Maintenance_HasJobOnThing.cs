using System.Reflection;
using HarmonyLib;
using ICantFixThat;
using Verse;
using Verse.AI;

namespace ICantFixThat_FluffyBreakdowns;

[HarmonyPatch]
public static class WorkGiver_Maintenance_HasJobOnThing
{
    public static MethodBase TargetMethod()
    {
        return AccessTools.Method("Fluffy_Breakdowns.WorkGiver_Maintenance:HasJobOnThing",
            new[] { typeof(Pawn), typeof(Thing), typeof(bool) });
    }

    public static void Postfix(ref bool __result, Pawn pawn, Thing thing)
    {
        if (!__result)
        {
            return;
        }

        if (!pawn.Faction.IsPlayer)
        {
            return;
        }

        if (Main.CanRepair(thing))
        {
            return;
        }

        JobFailReason.Is("ICFT.NoKnowledge.reason".Translate());
        __result = false;
    }
}