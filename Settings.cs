namespace aspnetcoreapi;

public sealed class Settings
{
    public int KeyOne { get; set; }
    public bool KeyTwo { get; set; }
    public Item KeyThree { get; set; } = null!;
    public string[] IPAddressRange { get; set; } = null!;
}

public class Item
{
    public string Message { get; set; } = null!;
    public Dictionary<string, string> SupportedVersions { get; set; } = null!;
}
