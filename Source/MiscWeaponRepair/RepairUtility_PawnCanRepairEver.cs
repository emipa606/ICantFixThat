using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat;

[HarmonyPatch]
public static class RepairUtility_PawnCanRepairEver
{
    public static MethodBase TargetMethod()
    {
        return AccessTools.Method("WeaponRepair.CompWeaponRepairTwo2One:GetAvailableTwinThing", [typeof(Pawn)]);
    }

    public static void Postfix(ref Thing __result)
    {
        if (__result == null)
        {
            return;
        }

        if (!Main.CanRepair(__result))
        {
            __result = null;
        }
    }
}