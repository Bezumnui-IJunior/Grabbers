using Bases.Transitions;
using Misc;
using StateMachines;

namespace Bases.States
{
    public class CollectingState : State
    {
        private readonly TaskDispatcher _dispatcher;
        private readonly BringTaskCreator _taskCreator;

        public CollectingState(IStateChanger stateChanger, TaskDispatcher dispatcher, BringTaskCreator taskCreator, int price, IWarehouse warehouse, BaseCreator baseCreator) : base(
            stateChanger)
        {
            _dispatcher = dispatcher;
            _taskCreator = taskCreator;
            AddTransition(new CollectingToCreateNewBot(stateChanger, warehouse, price));
            AddTransition(new CollectingToEarningForBase(stateChanger, baseCreator));
        }

        public override void Enter()
        {
            _dispatcher.Enable();
            _taskCreator.Enable();
        }

        public override void Exit()
        {
            _dispatcher.Disable();
            _taskCreator.Disable();
        }
    }
}