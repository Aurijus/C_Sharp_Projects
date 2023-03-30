using System;
using ND1;
using System.Security.Cryptography;

public class GPU : IElement, IEquatable<GPU?>
{
	public string? Name { get; private set; }
	public string? Model { get; private set; } 
	public int? MaxFreq { get; private set; }
	public bool VulcanSupport { get; private set; }

	public string Description => ToString();

	public GPU(string name, string model, int maxFreq, bool vulcanSupport)
	{
		Name = name;
		Model = model;
		MaxFreq = maxFreq;
		VulcanSupport = vulcanSupport;
	}

    public GPU()
    {
    }

    public override string ToString()
    {
        return $"Part: {nameof(GPU)}\n" +
				$"\tVendor: {Name}\n" +
				$"\tModel: {Model}\n" + 
				$"\tMax Frequency: {MaxFreq} MHz\n" + 
				$"\tVulcan Support: {(VulcanSupport ? "Yes" : "No")}\n";
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as GPU);
    }

    public bool Equals(GPU? other)
    {
        return other is not null &&
               Name == other.Name &&
               Model == other.Model &&
               MaxFreq == other.MaxFreq &&
               VulcanSupport == other.VulcanSupport &&
               Description == other.Description;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Model, MaxFreq, VulcanSupport, Description);
    }

    public static bool operator ==(GPU? left, GPU? right)
    {
        return EqualityComparer<GPU>.Default.Equals(left, right);
    }

    public static bool operator !=(GPU? left, GPU? right)
    {
        return !(left == right);
    }
}
