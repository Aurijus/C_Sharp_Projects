﻿namespace ND1
{
    public interface IElement
    {
        string Name { get; }
        string Description { get; }
    }

    public interface IElementContainer : IElement
    {
        string GetFullDescription();
        IElement? GetElementByName(string name);
        IEnumerable<IElement> GetElementsByName(string name);
        T? GetElementByType<T>() where T : IElement;
        IEnumerable<T> GetElementsByType<T>() where T : IElement;
        IEnumerable<IElement> GetAllElements();
    }
}
