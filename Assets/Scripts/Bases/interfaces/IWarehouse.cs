using System.Collections.Generic;

namespace Bases
{
    public interface IWarehouse
    {
        public void CopyItems(List<InventoryItem> items);
    }
}