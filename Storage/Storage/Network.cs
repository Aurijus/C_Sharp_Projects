using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 14) Network class, that inherits IEnumerable<Item>
 */

public class Network : IEnumerable<Item>
 {
    public List<Storage> network { get; set; }
    public Network() => network ??= new List<Storage>();

    public void AddWarehouse(Storage warehouse) => network.Add(warehouse); // 15) AddWarehouse(Warehouse warehouse) realized.

    public IEnumerator<Item> GetEnumerator()
    {
            foreach (Storage storage in network)
                foreach (Item i in storage)
                    yield return i;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
