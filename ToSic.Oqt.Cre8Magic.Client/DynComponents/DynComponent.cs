namespace ToSic.Oqt.Cre8Magic.Client.DynComponents;

public class DynComponent
{
    public DynComponent(string group, Type type, Dictionary<string, object>? parameters)
    {
        Group = group;
        Type = type;
        Parameters = parameters;
    }

    public string Group { get; set; }

    public Type Type { get; set; }

    public Dictionary<string, object>? Parameters { get; set; }
}