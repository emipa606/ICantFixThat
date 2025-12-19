using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat_OgRepairYourGear;

[StaticConstructorOnStartup]
public static class OgRepairYourGear
{
    static OgRepairYourGear()
    {
        Log.Message("[ICantFixThat]: Adding compatibility with [Og] Repair Your Gear");
        new Harmony("Mlie.ICantFixThat.OgRepairYourGear").PatchAll(Assembly.GetExecutingAssembly());
    }
}