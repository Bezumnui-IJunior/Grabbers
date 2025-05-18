using System;
using Base;
using UnityEngine;

namespace Bot
{
    [RequireComponent(typeof(Collider))]
    public class DropOffer : MonoBehaviour
    {
        [SerializeField] private BaseMember _baseMember;
        private Inventory _inventory;
        private bool _isInsideArea;
        public event Action BaseEntered;

        private void OnTriggerEnter(Collider other)
        {
            DoIfMember(other, EnterBase);
        }

        private void OnTriggerExit(Collider other)
        {
            DoIfMember(other, () => { _isInsideArea = false; });
        }

        private void EnterBase()
        {
            _isInsideArea = true;
            BaseEntered?.Invoke();
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
            if (_isInsideArea == false)
                throw new Exception($"{_isInsideArea} is false. Cannot extract.");

            _baseMember.Base.DropOffArea.Load(_inventory.TransferItems());
        }

        public void Init(Inventory inventory)
        {
            _inventory = inventory;
        }
    }
}