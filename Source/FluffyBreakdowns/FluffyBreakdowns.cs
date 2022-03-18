using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat_FluffyBreakdowns;

[StaticConstructorOnStartup]
public static class FluffyBreakdowns
{
    static FluffyBreakdowns()
    {
        new Harmony("Mlie.ICantFixThat.FluffyBreakdowns").PatchAll(Assembly.GetExecutingAssembly());
    }
}