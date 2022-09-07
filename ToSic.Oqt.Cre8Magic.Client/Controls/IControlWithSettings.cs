using Microsoft.AspNetCore.Components;

namespace ToSic.Oqt.Cre8Magic.Client.Controls;

public interface IControlWithSettings
{
    [CascadingParameter] CurrentSettings Settings { get; set; }
}