using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat;

[StaticConstructorOnStartup]
public static class MiscWeaponRepair
{
    static MiscWeaponRepair()
    {
        new Harmony("Mlie.ICantFixThat.MiscWeaponRepair").PatchAll(Assembly.GetExecutingAssembly());
    }
}