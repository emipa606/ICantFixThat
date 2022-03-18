using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat;

[StaticConstructorOnStartup]
public static class RepairItems
{
    static RepairItems()
    {
        new Harmony("Mlie.ICantFixThat.RepairItems").PatchAll(Assembly.GetExecutingAssembly());
    }
}