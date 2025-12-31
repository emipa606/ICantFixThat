using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat_GlittertechExpansion;

[StaticConstructorOnStartup]
public static class GlittertechExpansion
{
    static GlittertechExpansion()
    {
        Log.Message("[ICantFixThat]: Adding compatibility with Glittertech Expansion");
        new Harmony("Mlie.ICantFixThat.GlittertechExpansion").PatchAll(Assembly.GetExecutingAssembly());
    }
}