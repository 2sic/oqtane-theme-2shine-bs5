namespace ToSic.Oqt.Cre8ive.Client.Settings;

public partial class ThemePackageSettings
{
    internal static ThemePackageSettings Fallback = new()
    {
        Defaults = new()
        {
            Source = "Preset",
            ContainerDesigns = new()
            {
                { Constants.Default, ContainerDesign.Defaults }
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
                { Constants.Default, LanguageDesign.Defaults }
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
                { Constants.Default, MenuDesign.Defaults },
                // The Design configuration for Mobile menus, if not overridden by the JSON
                { Constants.DesignMobile, MenuDesign.MobileDefaults }
            }
        }
    };
}