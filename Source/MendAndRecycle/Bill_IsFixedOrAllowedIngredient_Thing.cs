using HarmonyLib;
using RimWorld;
using Verse;

namespace ICantFixThat;

[HarmonyPatch(typeof(Bill), "IsFixedOrAllowedIngredient", typeof(Thing))]
public static class Bill_IsFixedOrAllowedIngredient_Thing
{
    public static void Postfix(ref bool __result, Bill __instance, Thing thing)
    {
        if (!__result)
        {
            return;
        }

        if (!MendAndRecycle.MendingRecipesList.Contains(__instance.recipe.defName))
        {
            return;
        }

        __result = Main.CanRepair(thing);
    }
}