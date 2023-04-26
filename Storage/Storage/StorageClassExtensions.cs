using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class StorageClassExtensions
// Extensions methods for Storage class
{
    public static IEnumerable<Item> SortByName(this IEnumerable<Item> storage)
    // 4) SortByName() realized.
    {
        return storage.OrderBy(i => i.Name);
    }

    public static IEnumerable<Item> SortByPrice(this IEnumerable<Item> storage)
    // 5) SortByPrice() realized.
    {
        return storage.OrderBy(i => i.Price);
    }

    public static IEnumerable<Item> SortByQuantity(this IEnumerable<Item> storage)
    // 6) SortByQuantity() realized.
    {
        return storage.OrderBy(i => i.Quantity);
    }

    public static Item? GetCheapestProduct(this IEnumerable<Item> storage)
    // 7) GetCheapestProduct() realized.
    {
        Item? item = null;
        storage = storage.OrderBy(i => i.Price);
        item = storage.FirstOrDefault();
        return item;
    }

    public static Item? GetMostExpensiveProduct(this IEnumerable<Item> storage)
    // 8) GetMostExpensiveProduct() realized.
    {
        Item? item = null;
        storage = storage.OrderByDescending(i => i.Price);
        item = storage.FirstOrDefault();
        return item;
    }

    public static IEnumerable<Item> GetProductsByPriceRange(this IEnumerable<Item> storage, decimal minPrice, decimal maxPrice)
    // 9) GetProductsByPriceRange(decimal minPrice, decimal maxPrice) realized.
    {
        foreach (Item i in storage)
            if ((i?.Price ?? 0) >= minPrice && (i?.Price ?? 0) <= maxPrice)
                yield return i;
    }

    public static IEnumerable<Item> GetProductsByQuantity(this IEnumerable<Item> storage, int minQuantity, int maxQuantity)
    // 10) GetProductsByQuantity(int minQuantity, int maxQuantity) realized.
    {
        foreach (Item i in storage)
            if ((i?.Quantity ?? 0) >= minQuantity && (i?.Quantity ?? 0) <= maxQuantity)
                yield return i;
    }

    public static IEnumerable<Item> GetProductsByName(this IEnumerable<Item> storage, string name)
    // 11) GetProductsByName(string name) realized.
    {
        foreach (Item i in storage)
            if (name == i.Name)
                yield return i;
    }

    public static IEnumerable<Item> GetProductsByPriceLessThan(this IEnumerable<Item> storage, decimal price)
    // 12) GetProductsByPriceLessThan(decimal price)
    {
        foreach (Item i in storage)
            if (i.Price <= price)
                yield return i;
    }

    public static IEnumerable<Item> GetProductsByPriceGreaterThan(this IEnumerable<Item> storage, decimal price)
    // 13) GetProductsByPriceGreaterThan(decimal price)
    {
        foreach (Item i in storage)
            if (i.Price >= price)
                yield return i;
    }
}