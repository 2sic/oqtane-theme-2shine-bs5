using Microsoft.AspNetCore.Components;

namespace ToSic.Oqt.Cre8ive.Client.Controls;

public interface IControlWithSettings
{
    [CascadingParameter] CurrentSettings Settings { get; set; }
}