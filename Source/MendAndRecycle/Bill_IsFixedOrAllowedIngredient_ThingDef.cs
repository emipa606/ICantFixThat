using HarmonyLib;
using RimWorld;
using Verse;

namespace ICantFixThat;

[HarmonyPatch(typeof(Bill), "IsFixedOrAllowedIngredient", typeof(ThingDef))]
public static class Bill_IsFixedOrAllowedIngredient_ThingDef
{
    public static void Postfix(ref bool __result, Bill __instance, ThingDef def)
    {
        if (!__result)
        {
            return;
        }

        if (!MendAndRecycle.MendingRecipesList.Contains(__instance.recipe.defName))
        {
            return;
        }

        __result = Main.CanRepair(def);
    }
}