using UnityEngine;

namespace Bot.States
{
    public class CollectingState : State, ICollectingState
    {
        [SerializeField] private ItemDetector _itemDetector;
        private IInventory _inventory;

        private IBotTasker _tasker;

        private void OnEnable()
        {
            if (_itemDetector.TryGiveItem(_tasker.Task.Id, out ICollectable collectable))
                collectable.Collect(_inventory);

            ChangeState<IReturnState>();
        }

        public void Init(IBotTasker tasker, IInventory inventory)
        {
            _tasker = tasker;
            _inventory = inventory;
        }
    }
}