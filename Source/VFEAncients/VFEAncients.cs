﻿using System.Reflection;
using HarmonyLib;
using Verse;

namespace ICantFixThat_VFEAncients;

[StaticConstructorOnStartup]
public static class VFEAncients
{
    static VFEAncients()
    {
        new Harmony("Mlie.ICantFixThat.VFEAncients").PatchAll(Assembly.GetExecutingAssembly());
    }
}