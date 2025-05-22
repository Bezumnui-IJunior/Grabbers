using StateMachines;

namespace Bots.Transitions
{
    public class GoToTaskByTypeTransition<TState> : Transition<TState> where TState : State
    {
        private readonly PointFollower _pointFollower;
        private readonly IBotTasker _tasker;
        private readonly BotTasks _type;

        protected GoToTaskByTypeTransition(IStateChanger stateChanger, PointFollower pointFollower, IBotTasker tasker, BotTasks type) : base(stateChanger)
        {
            _pointFollower = pointFollower;
            _tasker = tasker;
            _type = type;
        }

        protected override bool CanTransit() =>
            _pointFollower.IsBusy == false && _tasker.BotTask.Type == _type;
    }
}