using System.Reflection;
using HarmonyLib;
using ICantFixThat;
using RimWorld;
using Verse;
using VFEAncients;

namespace ICantFixThat_VFEAncients;

[HarmonyPatch]
public static class WorkGiver_Repair_FindDamagedItems
{
    public static MethodBase TargetMethod()
    {
        return AccessTools.Method("VFEAncients.HarmonyPatches.MendingPatches:ExtraVerificationCheck",
            new[] { typeof(Bill), typeof(Thing) });
    }

    public static void Postfix(ref bool __result, Thing t, Bill bill)
    {
        if (!__result)
        {
            return;
        }

        if (bill.recipe == null || !bill.recipe.HasModExtension<RecipeExtension_Mend>())
        {
            return;
        }

        __result = Main.CanRepair(t);
    }
}