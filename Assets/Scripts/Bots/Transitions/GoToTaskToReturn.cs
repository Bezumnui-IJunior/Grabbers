using Bots.States;
using StateMachines;

namespace Bots.Transitions
{
    public class GoToTaskToReturn : Transition<ReturnState>
    {
        private readonly IBotTasker _tasker;

        public GoToTaskToReturn(IStateChanger stateChanger, IBotTasker tasker) : base(stateChanger)
        {
            _tasker = tasker;
        }

        protected override bool CanTransit() =>
            _tasker.BotTask.Type == BotTasks.BringItem && _tasker.BotTask.GetBringItemTask().Item.IsAlive == false;
    }
}