using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 2) Storage class, that inherits IEnumerable<Item>
 */

public class Storage : IEnumerable<Item>
{
    public IEnumerable<Item> items;

    public Storage() => items ??= new List<Item>();

    public IEnumerator<Item> GetEnumerator() // 3) GetEnumerator() realized
    {
        foreach(Item i in items)
            yield return i;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
