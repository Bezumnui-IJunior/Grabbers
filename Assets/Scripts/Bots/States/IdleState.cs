using Bots.Transitions;
using StateMachines;

namespace Bots.States
{
    public class IdleState : State
    {
        private readonly TransitionOnTask<FollowItemState> _itemTransition;
        private readonly TaskAcceptor _taskAcceptor;

        public IdleState(IStateChanger stateChanger, TaskAcceptor taskAcceptor, BotTasker tasker) : base(stateChanger)
        {
            _taskAcceptor = taskAcceptor;
            AddTransition(new TransitionOnTask<FollowItemState>(stateChanger, tasker, BotTasks.BringItem));
        }

        public override void Enter()
        {
            _taskAcceptor.GetReady();
        }
    }
}