using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat;

[StaticConstructorOnStartup]
public static class RepairItems
{
    static RepairItems()
    {
        Log.Message("[ICantFixThat]: Adding compatibility with Repair Items");
        new Harmony("Mlie.ICantFixThat.RepairItems").PatchAll(Assembly.GetExecutingAssembly());
    }
}