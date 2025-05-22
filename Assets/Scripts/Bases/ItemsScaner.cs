using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Bases
{
    [RequireComponent(typeof(Collider))]
    public class ItemsScanner : MonoBehaviour
    {
        private readonly List<Item> _items = new List<Item>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Item item))
                _items.Add(item);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Item item))
                _items.Remove(item);
        }

        public List<Item> GiveFound()
        {
            List<Item> result = new List<Item>(_items);
            _items.Clear();

            return result;
        }
    }
}