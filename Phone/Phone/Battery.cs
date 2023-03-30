using System;
using ND1;

public class Battery : IElement, IEquatable<Battery?>
{
    public string? Name { get; private set; }
    public int? Capacity { get; private set; }
    public double? Voltage { get; private set; }
    public double? ChargeTime { get; private set; }
    public bool Replacable { get; private set; }

    public string Description => ToString();

    public Battery(string name, int capacity, double voltage, double chargeTime, bool replacable)
    {
        Name = name;
        Capacity = capacity;
        Voltage = voltage;
        ChargeTime = chargeTime;
        Replacable = replacable;
    }

    public Battery()
    {
    }

    public override string ToString()
    {
        return $"Part: {nameof(Battery)}\n" +
                $"\tBattery type: {Name}\n" +
                $"\tCapacity: {Capacity} mAh\n" +
                $"\tCharger output power: {Voltage} V\n" +
                $"\tCharge time: {ChargeTime} hrs\n" +
                $"\tReplacable by user: {(Replacable ? "Yes" : "No")}\n";
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Battery);
    }

    public bool Equals(Battery? other)
    {
        return other is not null &&
               Name == other.Name &&
               Capacity == other.Capacity &&
               Voltage == other.Voltage &&
               ChargeTime == other.ChargeTime &&
               Replacable == other.Replacable &&
               Description == other.Description;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Capacity, Voltage, ChargeTime, Replacable, Description);
    }

    public static bool operator ==(Battery? left, Battery? right)
    {
        return EqualityComparer<Battery>.Default.Equals(left, right);
    }

    public static bool operator !=(Battery? left, Battery? right)
    {
        return !(left == right);
    }
}