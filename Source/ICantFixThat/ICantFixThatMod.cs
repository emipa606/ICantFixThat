using System;
using Mlie;
using RimWorld;
using UnityEngine;
using Verse;

namespace ICantFixThat;

[StaticConstructorOnStartup]
internal class ICantFixThatMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static ICantFixThatMod instance;

    private static string currentVersion;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public ICantFixThatMod(ModContentPack content) : base(content)
    {
        instance = this;
        Settings = GetSettings<ICantFixThatSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal ICantFixThatSettings Settings { get; }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "I Cant Fix That";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();
        listing_Standard.CheckboxLabeled("ICFT.AlsoBlockTechlevel".Translate(), ref Settings.AlsoBlockTechlevel);
        if (Settings.AlsoBlockTechlevel)
        {
            listing_Standard.Label("ICFT.AlsoBlockTechlevelLevel".Translate(Settings.AlsoBlockTechlevelLevel));
            Settings.AlsoBlockTechlevelLevel = (float)Math.Round(Widgets.HorizontalSlider_NewTemp(
                listing_Standard.GetRect(20),
                Settings.AlsoBlockTechlevelLevel, 0, Enum.GetValues(typeof(TechLevel)).Length - 1));

            if (Current.Game != null)
            {
                var playerTechLevel = Faction.OfPlayer.def.techLevel.ToStringHuman();
                var maxTechLevel = ((TechLevel)Math.Min(
                    (int)Faction.OfPlayer.def.techLevel + Settings.AlsoBlockTechlevelLevel,
                    Enum.GetValues(typeof(TechLevel)).Length - 1)).ToStringHuman();
                listing_Standard.Label("ICFT.TechLevelExplanation".Translate(playerTechLevel, maxTechLevel));
            }
        }

        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("ICFT.CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }
}