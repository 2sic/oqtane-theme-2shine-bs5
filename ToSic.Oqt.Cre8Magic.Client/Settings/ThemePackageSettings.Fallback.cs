namespace ToSic.Oqt.Cre8Magic.Client.Settings;

public partial class ThemePackageSettings
{
    internal static ThemePackageSettings Fallback = new()
    {
        Defaults = new()
        {
            Source = "Preset",
            ContainerDesigns = new()
            {
                { Constants.Default, MagicContainerDesignSettings.Defaults }
            },

            Layouts = new()
            {
                { Constants.Default, LayoutSettings.Defaults }
            },

            Languages = new()
            {
                { Constants.Default, LanguagesSettings.Defaults }
            },
            LanguageDesigns = new()
            {
                { Constants.Default, MagicLanguageDesignSettings.Defaults }
            },
            Breadcrumbs = new()
            {
                { Constants.Default, BreadcrumbSettings.Defaults }
            },
            Menus = new()
            {
                { Constants.Default, MagicMenuSettings.Defaults },
            },
            MenuDesigns = new()
            {
                // The Default design, if not overridden in the JSON
                { Constants.Default, MagicMenuDesignSettings.Defaults },
                // The Design configuration for Mobile menus, if not overridden by the JSON
                { Constants.DesignMobile, MagicMenuDesignSettings.MobileDefaults }
            }
        }
    };
}