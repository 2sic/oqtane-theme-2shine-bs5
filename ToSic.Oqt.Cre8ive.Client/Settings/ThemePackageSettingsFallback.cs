namespace ToSic.Oqt.Cre8ive.Client.Settings;

internal class ThemePackageSettingsFallback: ThemePackageSettingsBase
{
    private LayoutsSettings _defaults;

    public override LayoutsSettings Defaults => _defaults;
}