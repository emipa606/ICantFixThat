using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat_RepairableGear;

[StaticConstructorOnStartup]
public static class RepairableGear
{
    static RepairableGear()
    {
        Log.Message("[ICantFixThat]: Adding compatibility with Repairable Gear");
        new Harmony("Mlie.ICantFixThat.RepairableGear").PatchAll(Assembly.GetExecutingAssembly());
    }
}