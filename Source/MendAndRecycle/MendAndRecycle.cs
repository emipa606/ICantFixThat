using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat;

[StaticConstructorOnStartup]
public static class MendAndRecycle
{
    public static readonly List<string> MendingRecipesList;

    static MendAndRecycle()
    {
        MendingRecipesList = new List<string>
        {
            "MendSimpleApparel",
            "MendComplexApparel",
            "MendSimpleWeapon",
            "MendComplexWeapon"
        };
        new Harmony("Mlie.ICantFixThat.MendAndRecycle").PatchAll(Assembly.GetExecutingAssembly());
    }
}