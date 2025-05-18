using System;
using Base;
using Bot;
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
            DoIfMember(other, EnterBase);
        }

        private void OnTriggerExit(Collider other)
        {
            DoIfMember(other, () => { IsInsideBase = false; });
        }

        private void EnterBase()
        {
            IsInsideBase = true;
        }

        private void DoIfMember(Collider other, Action action)
        {
            if (other.TryGetComponent(out IBase @base) == false)
                return;

            if (@base == _baseMember.Base)
                action();
        }

        public void Unload()
        {
            if (IsInsideBase == false)
                throw new Exception($"{IsInsideBase} is false. Cannot extract.");

            _baseMember.Base.DropOffArea.Load(_inventory.TransferItems());
        }

        public void Init(Inventory inventory)
        {
            _inventory = inventory;
        }
    }
}