using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat_SimpleMending;

[StaticConstructorOnStartup]
public static class SimpleMending
{
    static SimpleMending()
    {
        Log.Message("[ICantFixThat]: Adding compatibility with Simple Mending");
        new Harmony("Mlie.ICantFixThat.SimpleMending").PatchAll(Assembly.GetExecutingAssembly());
    }
}