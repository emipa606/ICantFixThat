using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat_VFEAncients;

[StaticConstructorOnStartup]
public static class RepairWorkbench
{
    static RepairWorkbench()
    {
        new Harmony("Mlie.ICantFixThat.RepairWorkbench").PatchAll(Assembly.GetExecutingAssembly());
    }
}