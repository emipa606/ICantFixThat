using Verse;

namespace ICantFixThat;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class ICantFixThatSettings : ModSettings
{
    public bool AlsoBlockTechlevel;
    public float AlsoBlockTechlevelLevel = 1f;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref AlsoBlockTechlevel, "AlsoBlockTechlevel", true);
        Scribe_Values.Look(ref AlsoBlockTechlevelLevel, "AlsoBlockTechlevelLevel", 5f);
    }
}