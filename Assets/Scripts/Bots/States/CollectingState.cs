using Bot;
using Bots.Transitions;
using Misc;
using StateMachines;

namespace Bots.States
{
    public class CollectingState : State
    {
        private readonly IInventory _inventory;
        private readonly ItemDetector _itemDetector;
        private readonly IBotTasker _tasker;
        private readonly CooldownTimer _timer;

        public CollectingState(IStateChanger stateChanger, ItemDetector itemDetector, IInventory inventory,
            IBotTasker tasker, CooldownTimer timer) : base(stateChanger)
        {
            _itemDetector = itemDetector;
            _inventory = inventory;
            _tasker = tasker;
            _timer = timer;
            AddTransition(new DelayedTransition<ReturnState>(stateChanger, timer));
        }

        public override void Enter()
        {
            BringItemTask task = _tasker.BotTask.GetBringItemTask();

            if (_itemDetector.TryGiveItem(task.ItemId, out ICollectable collectable))
                collectable.Collect(_inventory);

            _timer.Start();
        }
    }
}