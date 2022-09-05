namespace ToSic.Oqt.Cre8ive.Client.Settings;

internal class ThemePackageSettingsFallback: ThemePackageSettings
{
    private LayoutsSettings _defaults;

    public override LayoutsSettings Defaults => _defaults;
}