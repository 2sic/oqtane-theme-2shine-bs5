namespace ToSic.Oqt.Cre8ive.Client.Settings;

public partial class ThemePackageSettings
{
    internal static ThemePackageSettings Fallback = new()
    {
        Defaults = new()
        {
            Source = "Preset",
            Layout = LayoutSettings.Defaults,
            Languages = LanguagesSettings.Defaults,
            LanguageDesigns = new()
            {
                { Constants.Default, LanguageDesignSettings.Defaults }
            },
            Breadcrumbs = new()
            {
                { Constants.Default, BreadcrumbSettings.Defaults }
            },
            Menus = new()
            {
                { Constants.Default, MenuConfig.Defaults },
            },
            MenuDesigns = new()
            {
                // The Default design, if not overridden in the JSON
                { Constants.Default, MenuDesignSettings.Defaults },
                // The Design configuration for Mobile menus, if not overridden by the JSON
                { Constants.DesignMobile, MenuDesignSettings.MobileDefaults }
            }
        }
    };
}