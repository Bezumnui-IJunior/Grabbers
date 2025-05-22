using System;
using Bases;
using UnityEngine;

namespace Bots
{
    [RequireComponent(typeof(Collider))]
    public class DropOffer : MonoBehaviour, IBaseConsistencyProvider
    {
        [SerializeField] private BaseMember _baseMember;
        private Inventory _inventory;
        public bool IsInsideBase { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            DoIfMember(other, () => IsInsideBase = true);
        }

        private void OnTriggerExit(Collider other)
        {
            DoIfMember(other, () => { IsInsideBase = false; });
        }

        private void DoIfMember(Collider other, Action action)
        {
            if (other.TryGetComponent(out IMembersStorage storage) == false)
                return;

            if (storage == _baseMember.MembersStorage)
                action();
        }

        public void Unload()
        {
            if (IsInsideBase == false)
                throw new Exception($"{IsInsideBase} is false. Cannot extract.");

            _baseMember.MembersStorage.DropOffArea.Load(_inventory.TransferItems());
        }

        public void Init(Inventory inventory)
        {
            _inventory = inventory;
        }
    }
}