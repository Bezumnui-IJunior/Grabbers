using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public class DropOffArea : MonoBehaviour, IDropOffArea
    {
        private Warehouse _warehouse;

        public void Load(IEnumerable<CollectedItem> items)
        {
            foreach (CollectedItem item in items)
                _warehouse.AddItem(item);
        }

        public void Init(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }
    }
}