using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat_VFEAncients;

[StaticConstructorOnStartup]
public static class VFEAncients
{
    static VFEAncients()
    {
        Log.Message("[ICantFixThat]: Adding compatibility with Vanilla Factions Expanded - Ancients");
        new Harmony("Mlie.ICantFixThat.VFEAncients").PatchAll(Assembly.GetExecutingAssembly());
    }
}