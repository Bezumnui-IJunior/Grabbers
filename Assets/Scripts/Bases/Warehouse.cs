using System.Collections.Generic;
using System.Linq;
using Items;

namespace Bases
{
    public class Warehouse : IWarehouse
    {
        private readonly List<InventoryItem> _items = new List<InventoryItem>();

        public int Amount => _items.Sum(item => item.Count);

        public void RemoveItems(int count)
        {
            if (count > Amount || count < 0)
                return;

            foreach (InventoryItem item in _items)
            {
                if (item.Count < count)
                {
                    count -= item.Count;
                    item.Remove(item.Count);
                }

                else
                {
                    item.Remove(count);

                    return;
                }
            }
        }

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