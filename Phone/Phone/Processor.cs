using System;
using ND1;

public class Processor : IElement, IEquatable<Processor?>
{
    public string? Name { get; private set; }
    public int? Size { get; private set; }
    public int? Cores { get; private set; }
    public int? Architecture { get; private set; }

    public string Description => ToString();

    public Processor(string name, int size, int cores, int architecture)
    {
        Name = name;
        Size = size;
        Cores = cores;
        Architecture = architecture;
    }

    public Processor()
    {
    }

    public override string ToString()
    {
        return $"Part: {nameof(Processor)}\n" +
                $"\tCPU: {Name}\n" +
                $"\tSize: {Size} nm\n" +
                $"\tCores: {Cores}\n" +
                $"\tArchitecture: {Architecture}-bit\n";
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Processor);
    }

    public bool Equals(Processor? other)
    {
        return other is not null &&
               Name == other.Name &&
               Size == other.Size &&
               Cores == other.Cores &&
               Architecture == other.Architecture &&
               Description == other.Description;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Size, Cores, Architecture, Description);
    }

    public static bool operator ==(Processor? left, Processor? right)
    {
        return EqualityComparer<Processor>.Default.Equals(left, right);
    }

    public static bool operator !=(Processor? left, Processor? right)
    {
        return !(left == right);
    }
}