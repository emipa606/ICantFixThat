using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using ICantFixThat;
using Verse;
using Verse.AI;

namespace ICantFixThat_LTSMaintenance;

[HarmonyPatch]
public static class WorkGivers_HasJobOnThing
{
    public static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method("Maintenance.WorkGivers.WorkGiverDoApparelsMaintenance:HasJobOnThing",
            [typeof(Pawn), typeof(Thing), typeof(bool)]);

        yield return AccessTools.Method("Maintenance.WorkGivers.WorkGiverDoWeaponsMaintenance:HasJobOnThing",
            [typeof(Pawn), typeof(Thing), typeof(bool)]);
    }

    public static void Postfix(ref bool __result, Pawn pawn, Thing t)
    {
        if (!__result)
        {
            return;
        }

        if (!Main.IsValidRepairer(pawn))
        {
            return;
        }

        if (t == null)
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