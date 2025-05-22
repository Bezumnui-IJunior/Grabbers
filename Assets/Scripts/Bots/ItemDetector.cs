using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Bots
{
    [RequireComponent(typeof(Collider))]
    public class ItemDetector : MonoBehaviour
    {
        private readonly List<Item> _items = new List<Item>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Item item) == false)
                return;

            _items.Add(item);
            item.Dying += RemoveItem;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Item item) == false)
                return;

            RemoveItem(item);
        }

        private void RemoveItem(Item item)
        {
            _items.Remove(item);
            item.Dying -= RemoveItem;
        }

        public bool TryGiveItem(Item item) =>
            _items.Contains(item);
    }
}