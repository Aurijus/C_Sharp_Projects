using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class NetworkClassExtensions
// Extensions methods for Network class
{
    public static decimal? GetTotalValue(this IEnumerable<Storage> network)
    // 16) GetTotalValue() realized.
    {
        decimal? sum = 0;
        foreach (Storage storage in network)
            foreach (Item i in storage.items)
                sum += i.Price;
        return sum;
    }

    public static int? GetTotalQuantity(this IEnumerable<Storage> network)
    // 17) GetTotalQuantity() realized.
    {
        int? sum = 0;
        foreach (Storage storage in network)
            foreach (Item i in storage.items)
                sum += i.Quantity;
        return sum;
    }

    public static IEnumerable<Item> GetProductsByWarehouse(this IEnumerable<Storage> network, Storage warehouse)
    // 18) GetProductsByWarehouse(Warehouse warehouse) realized.
    {
        foreach (Storage storage in network)
            if (warehouse == storage)
                foreach (Item item in storage)
                    yield return item;
    }

    public static IEnumerable<Item> GetProductsByPriceLessThan(this IEnumerable<Storage> network, decimal price, Storage warehouse)
    // 19) GetProductsByPriceLessThan(decimal price, Warehouse warehouse) realized.
    {
        foreach (Storage storage in network)
            if (warehouse == storage)
                foreach (Item item in storage)
                    if (price >= item.Price)
                        yield return item;
    }

    public static IEnumerable<Item> GetProductsByPriceGreaterThan(this IEnumerable<Storage> network, decimal price, Storage warehouse)
    // 20) GetProductsByPriceGreaterThan(decimal price, Warehouse warehouse) realized.
    {
        foreach (Storage storage in network)
            if (warehouse == storage)
                foreach (Item item in storage)
                    if (price <= item.Price)
                        yield return item;
    }

    public static IEnumerable<Item> GetProductsByQuantity(this IEnumerable<Storage> network, int quantity, Storage warehouse)
    // 21) GetProductsByQuantity(int quantity, Warehouse warehouse) realized.
    {
        foreach (Storage storage in network)
            if (warehouse == storage)
                foreach (Item item in storage)
                    if (quantity == item.Quantity)
                        yield return item;
    }

    public static IEnumerable<Item> GetProductsByName(this IEnumerable<Storage> network, string name, Storage warehouse)
    // 22) GetProductsByName(string name, Warehouse warehouse) realized.
    {
        foreach (Storage storage in network)
            if (warehouse == storage)
                foreach (Item item in storage)
                    if (name == item.Name)
                        yield return item;
    }

    public static Item? GetCheapestProduct(this IEnumerable<Storage> network)
    // 23) GetCheapestProduct() realized.
    {
        Item? item = null;
        foreach (Storage storage in network)
            foreach (Item i in storage)
                if (item?.Price > i.Price)
                    item = i;
        return item;
    }

    public static Item? GetMostExpensiveProduct(this IEnumerable<Storage> network)
    // 24) GetMostExpensiveProduct() realized.
    {
        Item? item = null;
        foreach (Storage storage in network)
            foreach (Item i in storage)
                if (item?.Price < i.Price)
                    item = i;
        return item;
    }

    public static IEnumerable<Item> GetProductsByPriceRange(this IEnumerable<Storage> network, decimal minPrice, decimal maxPrice)
    // 25) GetProductsByPriceRange(decimal minPrice, decimal maxPrice) realized.
    {
        foreach (Storage storage in network)
            foreach (Item i in storage)
                if ((i?.Price ?? 0) >= minPrice && (i?.Price ?? 0) <= maxPrice)
                    yield return i;
    }

    public static IEnumerable<Item> GetProductsByQuantity(this IEnumerable<Storage> network, int minQuantity, int maxQuantity)
    // 26) GetProductsByQuantity(int minQuantity, int maxQuantity) realized.
    {
        foreach (Storage storage in network)
            foreach (Item i in storage)
                if ((i?.Quantity ?? 0) >= minQuantity && (i?.Quantity ?? 0) <= maxQuantity)
                    yield return i;
    }

    public static IEnumerable<Item> GetProductsByName(this IEnumerable<Storage> network, string name)
    // 27) GetProductsByName(string name) realized.
    {
        foreach (Storage storage in network)
            foreach (Item item in storage)
                if (name == item.Name)
                    yield return item;
    }

    public static IEnumerable<Item> GetProductsByPriceLessThan(this IEnumerable<Storage> network, decimal price)
    // 28) GetProductsByPriceLessThan(decimal price) realized.
    {
        foreach (Storage storage in network)
            foreach (Item i in storage)
                if (price >= i.Price)
                    yield return i;
    }

    public static IEnumerable<Item> GetProductsByPriceGreaterThan(this IEnumerable<Storage> network, decimal price)
    // 29) GetProductsByPriceGreaterThan(decimal price) realized.
    {
        foreach (Storage storage in network)
            foreach (Item i in storage)
                if (price <= i.Price)
                    yield return i;
    }
}