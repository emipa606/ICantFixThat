using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat_VFEAncients;

[StaticConstructorOnStartup]
public static class RepairWorkbench
{
    static RepairWorkbench()
    {
        Log.Message("[ICantFixThat]: Adding compatibility with Repair Workbench");
        new Harmony("Mlie.ICantFixThat.RepairWorkbench").PatchAll(Assembly.GetExecutingAssembly());
    }
}