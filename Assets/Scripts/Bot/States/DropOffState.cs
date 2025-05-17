using UnityEngine;

namespace Bot.States
{
    public class DropOffState : State, IDropOffState
    {
        [SerializeField] private DropOffer _dropOffer;

        private void OnEnable()
        {
            _dropOffer.Unload();
            ChangeState<IIdleState>();
        }

        public void Init(Inventory inventory)
        {
            _dropOffer.Init(inventory);
        }
    }
}