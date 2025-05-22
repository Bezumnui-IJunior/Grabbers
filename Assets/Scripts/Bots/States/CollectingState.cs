using Bot;
using Bots.Transitions;
using Items;
using StateMachines;

namespace Bots.States
{
    public class CollectingState : State
    {
        private readonly IInventory _inventory;
        private readonly ItemDetector _itemDetector;
        private readonly IBotTasker _tasker;

        public CollectingState(IStateChanger stateChanger, IBotTasker tasker, ItemDetector itemDetector, IInventory inventory) : base(stateChanger)
        {
            _tasker = tasker;
            _itemDetector = itemDetector;
            _inventory = inventory;
            AddTransition(new CollectingToReturn(stateChanger));
        }

        public override void Enter()
        {
            BringItemTask task = _tasker.BotTask.GetBringItemTask();

            Item item = task.Item;

            if (_itemDetector.TryGiveItem(item))
                item.Collect(_inventory);
        }
    }
}