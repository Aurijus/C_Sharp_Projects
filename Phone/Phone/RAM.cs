using System;
using ND1;

public class RAM : IElement, IEquatable<RAM?>
{
    public string? Name { get; private set; }
    public RamType? Type { get; private set; }
    public int? Size { get; private set; }
    public int? OperatingFreq { get; private set; }

    public string Description => ToString();

    public RAM(string name, RamType type, int size, int operatingFreq)
    {
        Name = name;
        Type = type;
        Size = size;
        OperatingFreq = operatingFreq;
    }
    public RAM()
    {
    }

    public override string ToString()
    {
        return $"Part: {nameof(RAM)}\n" +
                $"\tGeneration: {Name}\n" +
                $"\tType: {Type}\n" +
                $"\tSize: {Size} GB\n" +
                $"\tOperating (I/O) Frequency: {OperatingFreq} MHz\n";
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as RAM);
    }

    public bool Equals(RAM? other)
    {
        return other is not null &&
               Name == other.Name &&
               Type == other.Type &&
               Size == other.Size &&
               OperatingFreq == other.OperatingFreq &&
               Description == other.Description;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Type, Size, OperatingFreq, Description);
    }

    public enum RamType
    {
        LPDDR1,
        LPDDR1E,
        LPDDR2,
        LPDDR2E,
        LPDDR3,
        LPDDR3E,
        LPDDR4,
        LPDDR4X,
        LPDDR5,
        LPDDR5X
    }

    public static bool operator ==(RAM? left, RAM? right)
    {
        return EqualityComparer<RAM>.Default.Equals(left, right);
    }

    public static bool operator !=(RAM? left, RAM? right)
    {
        return !(left == right);
    }
}
