using StateMachines;

namespace Bots.Transitions
{
    public class TransitionOnTask<TState> : Transition<TState> where TState : State
    {
        private readonly BotTasker _tasker;
        private readonly BotTasks _type;

        public TransitionOnTask(IStateChanger stateChanger, BotTasker tasker, BotTasks type) : base(stateChanger)
        {
            _tasker = tasker;
            _type = type;
        }

        protected override bool CanTransit() =>
            _tasker.HasTask && _tasker.BotTask.Type == _type;
    }
}