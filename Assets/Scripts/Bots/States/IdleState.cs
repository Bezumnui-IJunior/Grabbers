using Bots.Transitions;
using StateMachines;

namespace Bots.States
{
    public class IdleState : State
    {
        private readonly TaskAcceptor _taskAcceptor;
        private readonly IdleToGoToTask _taskTransition;

        public IdleState(IStateChanger stateChanger, TaskAcceptor taskAcceptor, BotTasker tasker) : base(stateChanger)
        {
            _taskAcceptor = taskAcceptor;
            AddTransition(new IdleToGoToTask(stateChanger, tasker));
        }

        public override void Enter()
        {
            _taskAcceptor.GetReady();
        }
    }
}