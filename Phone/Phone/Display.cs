using System;
using ND1;

public class Display : IElement, IEquatable<Display?>
{
    public string? Name { get; private set; }
    public int[] Resolution { get; private set; }
    public double? Size { get; private set; }
    public int? RefreshRate { get; private set; }
    public string? Protection { get; private set; }

    public string Description => ToString();

    public Display(string name, int[] resolution, double size, int refreshRate, string protection)
    {
        Name = name;
        Resolution = new int[2];
        Resolution = resolution;
        Size = size;
        RefreshRate = refreshRate;
        Protection = protection;
    }

    public Display()
    {
    }

    public override string ToString()
    {
        return $"Part: {nameof(Display)}\n" +
                $"\tScreen: {Name}\n" +
                $"\tResolution: {Resolution[0]}x{Resolution[1]} px\n" +
                $"\tSize: {Size} inches\n" +
                $"\tRefresh rate: {RefreshRate} Hz\n" +
                $"\tProtection: {Protection}\n";
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Display);
    }

    public bool Equals(Display? other)
    {
        return other is not null &&
               Name == other.Name &&
               EqualityComparer<int[]>.Default.Equals(Resolution, other.Resolution) &&
               Size == other.Size &&
               RefreshRate == other.RefreshRate &&
               Protection == other.Protection &&
               Description == other.Description;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Resolution, Size, RefreshRate, Protection, Description);
    }

    public static bool operator ==(Display? left, Display? right)
    {
        return EqualityComparer<Display>.Default.Equals(left, right);
    }

    public static bool operator !=(Display? left, Display? right)
    {
        return !(left == right);
    }
}