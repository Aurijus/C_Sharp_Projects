using System;
using ND1;

public class Modules : IElement, IEquatable<Modules?>
{
    public string? Name { get; private set; }
    public List<Modems>? Modem { get; private set; }
    public List<Sensors>? Sensor { get; private set; }

    public string Description => ToString();

    public Modules(string name, List<Modems> modems, List<Sensors> sensors)
    {
        Name = name;
        Modem = new List<Modems>();
        Sensor = new List<Sensors>();
        Modem = modems;
        Sensor = sensors;

    }

    public Modules()
    {
    }

    public override string ToString()
    {
        return $"Part: {nameof(Modules)}\n" +
                $"\t{Name}: \n" +
                $"\tModems:\n" +
                $"\t\t{string.Join("\n\t\t", Modem)}\n" +
                $"\tSensor:\n" +
                $"\t\t{string.Join("\n\t\t", Sensor)}\n";
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Modules);
    }

    public bool Equals(Modules? other)
    {
        return other is not null &&
               Name == other.Name &&
               EqualityComparer<List<Modems>>.Default.Equals(Modem, other.Modem) &&
               EqualityComparer<List<Sensors>>.Default.Equals(Sensor, other.Sensor) &&
               Description == other.Description;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Modem, Sensor, Description);
    }

    public enum Modems
    {
        _1G,
        _2G,
        _3G,
        LTE,
        _5G,
        Bluetooth,
        WiFi,
        GPRS,
        GSM,
        HSPA
    }

    public enum Sensors
    {
        Temperature,
        Accelerometer,
        MagneticField,
        Gyroscope,
        Light,
        Gravity,
        Rotation,
        Pedometer,
        Proximity,
        Orientation,
        Fingerprint,
        Compass,
        HallSensor,
        IRBlaster
    }

    public static bool operator ==(Modules? left, Modules? right)
    {
        return EqualityComparer<Modules>.Default.Equals(left, right);
    }

    public static bool operator !=(Modules? left, Modules? right)
    {
        return !(left == right);
    }
}
