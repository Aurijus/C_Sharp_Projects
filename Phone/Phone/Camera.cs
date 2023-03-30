using System;
using ND1;

public class Camera : IElement, IEquatable<Camera?>
{
    public string? Name { get; private set; }
    public int? Resolution { get; private set; }
    public string? Aperture { get; private set; }
    public double? PixelSize { get; private set; }
    public bool IsFlash { get; private set; }

    public string Description => ToString();

    public Camera(string name, int resolution, string aperture, double pixelSize, bool isFlash)
    {
        Name = name;
        Resolution = resolution;
        Aperture = aperture;
        PixelSize = pixelSize;
        IsFlash = isFlash;
    }

    public Camera()
    {
    }

    public override string ToString()
    {
        return $"Part: {nameof(Camera)}\n" +
                $"\tCamera type: {Name}\n" +
                $"\tResolution: {Resolution} MP\n" +
                $"\tAperture: {Aperture}\n" +
                $"\tPixel size: {PixelSize} um\n" +
                $"\tHas flash: {(IsFlash ? "Yes" : "No")}\n";
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Camera);
    }

    public bool Equals(Camera? other)
    {
        return other is not null &&
               Name == other.Name &&
               Resolution == other.Resolution &&
               Aperture == other.Aperture &&
               PixelSize == other.PixelSize &&
               IsFlash == other.IsFlash &&
               Description == other.Description;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Resolution, Aperture, PixelSize, IsFlash, Description);
    }

    public static bool operator ==(Camera? left, Camera? right)
    {
        return EqualityComparer<Camera>.Default.Equals(left, right);
    }

    public static bool operator !=(Camera? left, Camera? right)
    {
        return !(left == right);
    }
}