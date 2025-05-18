using System.Collections.Generic;
using System.Linq;

namespace Bases
{
    public class Warehouse : IWarehouse
    {
        private readonly List<InventoryItem> _items = new List<InventoryItem>();

        public void CopyItems(List<InventoryItem> items)
        {
            items.Clear();
            items.AddRange(_items);
        }

        private bool TryGetItem(CollectedItem collected, out InventoryItem resultItem)
        {
            resultItem = null;

            foreach (InventoryItem inventoryItem in _items.Where(inventoryItem => inventoryItem.Name == collected.Name))
            {
                resultItem = inventoryItem;

                return true;
            }

            return false;
        }

        public void AddItem(CollectedItem collected)
        {
            if (TryGetItem(collected, out InventoryItem item) == false)
            {
                item = new InventoryItem(collected.Name);
                _items.Add(item);
            }

            item.IncrementCount();
        }
    }
}