using Bots.States;
using StateMachines;

namespace Bots.Transitions
{
    public class GoToTaskToBuildBase : GoToTaskByTypeTransition<BuildingBaseState>
    {
        public GoToTaskToBuildBase(IStateChanger stateChanger, PointFollower pointFollower, IBotTasker tasker) : base(stateChanger, pointFollower, tasker, BotTasks.BuildNewBase) { }
    }
}