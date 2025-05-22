using Bots.States;
using StateMachines;

namespace Bots.Transitions
{
    public class IdleToGoToTask : Transition<GoToTaskState>
    {
        private readonly BotTasker _tasker;

        public IdleToGoToTask(IStateChanger stateChanger, BotTasker tasker) : base(stateChanger)
        {
            _tasker = tasker;
        }

        protected override bool CanTransit() =>
            _tasker.HasTask;
    }
}