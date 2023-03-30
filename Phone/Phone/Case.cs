using System;
using System.Runtime.Intrinsics.X86;
using System.Text;
using ND1;

public class Case : IElementContainer, IEquatable<Case?>
{
    public string? Name { get; private set; }
    public string? Model { get; private set; }

    private SOC? _soc;
    private Display? _display;
    private List<Camera>? _cameras;
    private Battery? _battery;

    public string Description => ToString();

    private List<IElement> _elements;

    public Case(string name, string model, SOC soc, Display display, List<Camera> camera, Battery battery)
    {
        Name = name;
        Model = model;
        _soc = soc;
        _display = display;
        _battery = battery;
        _cameras = camera != null ? new List<Camera>(camera) : null;

        _elements = new List<IElement>
        {
            _soc,
            _display,
            _battery
        };

        if (_cameras != null)
        {
            _elements.AddRange(_cameras);
        }

        _elements = _elements.Where(x => x != null).ToList();
    }

    public Case(string name, string model) : this(name, model, null, null, null, null) { }

    public Case()
        : this("Smartphone not created", "No phone?", null, null, null, null) { }

    public override string ToString()
    {
        return $"Part: {nameof(Case)}\n" +
                $"\tVendor: {Name}\n" +
                $"\tModel: {Model}\n";
    }

    public string GetFullDescription()
    {
        StringBuilder stringBuild = new StringBuilder();
        stringBuild.AppendLine(Description);

        foreach (var element in _elements)
        {
            if (element is IElementContainer container)
                stringBuild.AppendLine(container.GetFullDescription());
            else
                stringBuild.AppendLine(element.Description);
        }

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
            if (element.GetType() == typeof(T))
                return element;
        return default(T?);
    }

    public IEnumerable<T> GetElementsByType<T>() where T : IElement
    {
        List<T> elements = new List<T>();
        foreach (T element in _elements)
            if (typeof(T) == typeof(T))
                elements.Add(element);
        return elements;
    }

    public IEnumerable<IElement> GetAllElements()
    {
        return _elements;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Case);
    }

    public bool Equals(Case? other)
    {
        return other is not null &&
               Name == other.Name &&
               Model == other.Model &&
               EqualityComparer<SOC?>.Default.Equals(_soc, other._soc) &&
               EqualityComparer<Display?>.Default.Equals(_display, other._display) &&
               EqualityComparer<List<Camera>?>.Default.Equals(_cameras, other._cameras) &&
               EqualityComparer<Battery?>.Default.Equals(_battery, other._battery) &&
               Description == other.Description &&
               EqualityComparer<List<IElement>>.Default.Equals(_elements, other._elements);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Model, _soc, _display, _cameras, _battery, Description, _elements);
    }

    public static bool operator ==(Case? left, Case? right)
    {
        return EqualityComparer<Case>.Default.Equals(left, right);
    }

    public static bool operator !=(Case? left, Case? right)
    {
        return !(left == right);
    }
}
