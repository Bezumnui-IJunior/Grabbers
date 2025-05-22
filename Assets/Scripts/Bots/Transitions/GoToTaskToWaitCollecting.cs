using Bots.States;
using StateMachines;

namespace Bots.Transitions
{
    public class GoToTaskToWaitCollecting : GoToTaskByTypeTransition<WaitCollectingState>
    {
        public GoToTaskToWaitCollecting(IStateChanger stateChanger, PointFollower pointFollower, IBotTasker tasker) : base(stateChanger, pointFollower, tasker, BotTasks.BringItem) { }
    }
}