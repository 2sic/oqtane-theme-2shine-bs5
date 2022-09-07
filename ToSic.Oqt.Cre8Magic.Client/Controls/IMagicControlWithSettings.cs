using Microsoft.AspNetCore.Components;

namespace ToSic.Oqt.Cre8Magic.Client.Controls;

public interface IMagicControlWithSettings
{
    [CascadingParameter] MagicSettings Settings { get; set; }
}