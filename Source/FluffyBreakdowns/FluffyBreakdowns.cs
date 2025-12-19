using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat_FluffyBreakdowns;

[StaticConstructorOnStartup]
public static class FluffyBreakdowns
{
    static FluffyBreakdowns()
    {
        Log.Message("[ICantFixThat]: Adding compatibility with Fluffy Breakdowns");
        new Harmony("Mlie.ICantFixThat.FluffyBreakdowns").PatchAll(Assembly.GetExecutingAssembly());
    }
}