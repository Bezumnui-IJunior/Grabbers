using System;
using Base;
using UnityEngine;

namespace Bot
{
    [RequireComponent(typeof(Collider))]
    public class DropOffer : MonoBehaviour
    {
        private IDropOffArea _area;
        private Inventory _inventory;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDropOffArea area))
                _area = area;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IDropOffArea _))
                _area = null;
        }

        public void Unload()
        {
            if (_area == null)
                throw new Exception($"{nameof(_area)} is null. Cannot extract.");

            _area.Load(_inventory.TransferItems());
        }

        public void Init(Inventory inventory)
        {
            _inventory = inventory;
        }
    }
}