using System;
using Bots.Transitions;
using StateMachines;

namespace Bots.States
{
    public class FollowItemState : State
    {
        private readonly PointFollower _pointFollower;
        private readonly IBotTasker _tasker;

        public FollowItemState(IStateChanger stateChanger, PointFollower pointFollower, IBotTasker tasker) : base(
            stateChanger)
        {
            _tasker = tasker;
            _pointFollower = pointFollower;
            AddTransition(new TransitionOnReach<CollectingState>(stateChanger, _pointFollower));
        }

        public override void Enter()
        {
            BringItemTask task = _tasker.BotTask.GetBringItemTask();

            if (_pointFollower.TrySetPath(task.Position) == false)
                throw new Exception("Invalid state");
        }
    }
}