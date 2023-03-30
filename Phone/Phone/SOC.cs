using System;
using System.Runtime.Intrinsics.X86;
using System.Text;
using ND1;

public class SOC : IElementContainer, IEquatable<SOC?>
{
    public string? Name { get; private set; }
    public string? Model { get; private set; }
    public string? Chipset { get; private set; }

    private Processor? _processor;
    private GPU? _gpu;
    private Modules? _modules;
    private RAM? _ram;
    private Storage? _storage;

    public string Description => ToString();

    private List<IElement>? _elements;

    public SOC(string name, string model, string chipset, Processor processor, GPU gpu, Modules modules, RAM ram, Storage storage)
    {
        Name = name;
        Model = model;
        Chipset = chipset;
        _processor = processor;
        _gpu = gpu;
        _modules = modules;
        _ram = ram;
        _storage = storage;

        _elements = new List<IElement>
        {
            _processor,
            _gpu,
            _modules,
            _ram,
            _storage
        };

        _elements = _elements.Where(x => x != null).ToList();
    }

    public SOC()
    {
    }

    public override string ToString()
    {
        return $"Part: {nameof(SOC)}\n" +
                $"\tVendor: {Name}\n" +
                $"\tModel: {Model}\n" +
                $"\tChipset: {Chipset}\n";
    }

    public string GetFullDescription()
    {
        StringBuilder stringBuild = new StringBuilder();
        stringBuild.AppendLine(Description);

        foreach (var element in _elements)
            stringBuild.AppendLine(element.Description);

        return stringBuild.ToString();
    }

    public IElement? GetElementByName(string name)
    {
        foreach (IElement element in _elements)
            if (element.Name == name)
                return element;
        return null;
    }

    public IEnumerable<IElement> GetElementsByName(string name)
    {
        List<IElement> elements = new List<IElement>();
        foreach (IElement element in _elements)
            if (element.Name.Equals(name))
                elements.Add(element);
        return elements;
    }

    public T? GetElementByType<T>() where T : IElement
    {
        foreach (T element in _elements)
            if(element.GetType() == typeof(T))
                return element;
        return default(T?);
    }

    public IEnumerable<T> GetElementsByType<T>() where T : IElement
    {
        List<T> elements = new List<T>();
        foreach(T element in _elements)
            if(typeof(T) == typeof(T))
                elements.Add(element);
        return elements;
    }

    public IEnumerable<IElement> GetAllElements()
    {
        return _elements;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as SOC);
    }

    public bool Equals(SOC? other)
    {
        return other is not null &&
               Name == other.Name &&
               Model == other.Model &&
               Chipset == other.Chipset &&
               EqualityComparer<Processor?>.Default.Equals(_processor, other._processor) &&
               EqualityComparer<GPU?>.Default.Equals(_gpu, other._gpu) &&
               EqualityComparer<Modules?>.Default.Equals(_modules, other._modules) &&
               EqualityComparer<RAM?>.Default.Equals(_ram, other._ram) &&
               EqualityComparer<Storage?>.Default.Equals(_storage, other._storage) &&
               Description == other.Description &&
               EqualityComparer<List<IElement>>.Default.Equals(_elements, other._elements);
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(Name);
        hash.Add(Model);
        hash.Add(Chipset);
        hash.Add(_processor);
        hash.Add(_gpu);
        hash.Add(_modules);
        hash.Add(_ram);
        hash.Add(_storage);
        hash.Add(Description);
        hash.Add(_elements);
        return hash.ToHashCode();
    }

    public static bool operator ==(SOC? left, SOC? right)
    {
        return EqualityComparer<SOC>.Default.Equals(left, right);
    }

    public static bool operator !=(SOC? left, SOC? right)
    {
        return !(left == right);
    }
}
