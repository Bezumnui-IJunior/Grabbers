using System.Collections.Generic;
using Bot;
using Items;

namespace Bots
{
    public class Inventory : IInventory
    {
        private readonly List<CollectedItem> _items = new List<CollectedItem>();

        public void Collect(Item item)
        {
            _items.Add(item.GetCollectedItem());
        }

        public List<CollectedItem> TransferItems()
        {
            List<CollectedItem> items = new List<CollectedItem>(_items);
            _items.Clear();

            return items;
        }
    }
}