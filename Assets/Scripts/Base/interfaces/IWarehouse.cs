using System.Collections.Generic;

namespace Base
{
    public interface IWarehouse
    {
        public void GetItems(List<InventoryItem> items);
        public bool TryGetItem(CollectedItem collected, out InventoryItem resultItem);
    }
}