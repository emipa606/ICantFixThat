using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat_LTSMaintenance;

[StaticConstructorOnStartup]
public static class LTSMaintenance
{
    static LTSMaintenance()
    {
        new Harmony("Mlie.ICantFixThat.LTSMaintenance").PatchAll(Assembly.GetExecutingAssembly());
    }
}