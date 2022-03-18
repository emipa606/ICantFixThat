using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat_RepairableGear;

[StaticConstructorOnStartup]
public static class RepairableGear
{
    static RepairableGear()
    {
        new Harmony("Mlie.ICantFixThat.RepairableGear").PatchAll(Assembly.GetExecutingAssembly());
    }
}