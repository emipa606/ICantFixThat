using System.Reflection;
using HarmonyLib;
using ICantFixThat;
using Verse;
using Verse.AI;

namespace ICantFixThat_LTSMaintenance;

[HarmonyPatch]
public static class WorkGiver_DoWeaponsMaintenance_HasJobOnThing
{
    public static MethodBase TargetMethod()
    {
        return AccessTools.Method("Maintenance.WorkGivers.WorkGiver_DoWeaponsMaintenance:HasJobOnThing",
            [typeof(Pawn), typeof(Thing), typeof(bool)]);
    }

    public static void Postfix(ref bool __result, Pawn pawn)
    {
        if (!__result)
        {
            return;
        }

        if (!Main.IsValidRepairer(pawn))
        {
            return;
        }

        var thing = pawn.equipment.PrimaryEq?.parent;
        if (thing == null)
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