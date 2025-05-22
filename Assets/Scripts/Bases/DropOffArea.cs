using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Bases
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