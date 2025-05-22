using System.Collections.Generic;

namespace Bases
{
    public interface IWarehouse
    {
        public int Amount { get; }
        public void RemoveItems(int count);
        public void CopyItems(List<InventoryItem> items);
    }
}