using System;
using ND1;

public class Storage : IElement, IEquatable<Storage?>
{
    public string? Name { get; private set; }
    public int? Size { get; private set; }
    public string? OperatingSystem { get; private set; }
    public bool Expandable { get; private set; }

    public string Description => ToString();

    public Storage(string name, int size, string operatingSystem, bool expandable)
    {
        Name = name;
        Size = size;
        OperatingSystem = operatingSystem;
        Expandable = expandable;
    }

    public Storage()
    {
    }

    public override string ToString()
    {
        return $"Part: {nameof(Storage)}\n" +
                $"\tVendor: {Name}\n" +
                $"\tSize: {Size} GB\n" +
                $"\tOperating System: {OperatingSystem}\n" +
                $"\tExpandable: {(Expandable ? "Yes" : "No")}\n";
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Storage);
    }

    public bool Equals(Storage? other)
    {
        return other is not null &&
               Name == other.Name &&
               Size == other.Size &&
               OperatingSystem == other.OperatingSystem &&
               Expandable == other.Expandable &&
               Description == other.Description;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Size, OperatingSystem, Expandable, Description);
    }

    public static bool operator ==(Storage? left, Storage? right)
    {
        return EqualityComparer<Storage>.Default.Equals(left, right);
    }

    public static bool operator !=(Storage? left, Storage? right)
    {
        return !(left == right);
    }
}
