﻿namespace ToSic.Oqt.Cre8ive.Client.Settings;

public class LayoutsSettings
{
    ///// <summary>
    ///// Version number when loading from JSON to verify it's what we expect
    ///// </summary>
    //public float Version { get; set; }

    /// <summary>
    /// Source of these settings / where they came from, to ensure that we can see in debug where a value was picked up from
    /// </summary>
    public string Source { get; set; } = "Unknown";

    public LayoutSettings? Layout { get; set; }

    public LanguagesSettings? Languages { get; set; }

    /// <summary>
    /// The menu definitions
    /// </summary>
    public Dictionary<string, MenuConfig> Menus { get; set; } = new();

    /// <summary>
    /// Design definitions of the menu
    /// </summary>
    public Dictionary<string, MenuDesignSettings> Designs { get; set; } = new();

    public MenuConfig? GetMenu(string name) => Menus.FindInvariant(name);
    public MenuDesignSettings? GetDesign(string name) => Designs.FindInvariant(name);
}

public class LayoutSettings
{
    public string? Logo { get; set; }
    public bool LanguageMenuShow { get; set; } = true;
    public int LanguageMenuShowMin { get; set; } = 0;

    public string? BreadcrumbSeparator { get; set; }
    public const string BreadcrumbSeparatorDefault = "&nbsp;&rsaquo;&nbsp;";

    public string? BreadcrumbReveal { get; set; }

    public const string BreadcrumbRevealDefault = "…"; // Ellipsis character
}