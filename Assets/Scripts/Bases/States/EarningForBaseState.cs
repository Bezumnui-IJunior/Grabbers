using Bases.Transitions;
using Bots;
using Misc;
using StateMachines;

namespace Bases.States
{
    public class EarningForBaseState : State
    {
        private readonly IBaseCreator _baseCreator;
        private readonly int _price;
        private readonly BringTaskCreator _taskCreator;
        private readonly TaskDispatcher _taskDispatcher;
        private readonly IWarehouse _warehouse;

        public EarningForBaseState(IStateChanger stateChanger, TaskDispatcher taskDispatcher, IBaseCreator baseCreator, BringTaskCreator taskCreator, int price, IWarehouse warehouse) : base(stateChanger)
        {
            _taskDispatcher = taskDispatcher;
            _baseCreator = baseCreator;
            _taskCreator = taskCreator;
            _price = price;
            _warehouse = warehouse;

            AddTransition(new EarningForBaseToCollecting(stateChanger, price, warehouse));
        }

        public override void Enter()
        {
            _taskDispatcher.Enable();
            _taskCreator.Enable();
        }

        public override void Exit()
        {
            _warehouse.RemoveItems(_price);
            _taskDispatcher.AddTask(new TypedTask(new BuildBaseTask(_baseCreator.Flag), BotTasks.BuildNewBase));
            _baseCreator.OnBuilt();
            _taskDispatcher.Disable();
            _taskCreator.Disable();
        }
    }
}