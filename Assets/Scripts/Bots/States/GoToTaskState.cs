using System;
using Bots.Transitions;
using StateMachines;

namespace Bots.States
{
    public class GoToTaskState : State
    {
        private readonly IBaseMember _member;
        private readonly PointFollower _pointFollower;
        private readonly IBotTasker _tasker;

        public GoToTaskState(IStateChanger stateChanger, PointFollower pointFollower, IBotTasker tasker, IBaseMember member)
            : base(stateChanger)
        {
            _tasker = tasker;
            _member = member;
            _pointFollower = pointFollower;
            AddTransition(new GoToTaskToWaitCollecting(stateChanger, _pointFollower, tasker));
            AddTransition(new GoToTaskToBuildBase(stateChanger, _pointFollower, tasker));
            AddTransition(new GoToTaskToReturn(stateChanger, tasker));
        }

        public override void Enter()
        {
            if (_tasker.BotTask.Type == BotTasks.BuildNewBase)
                _member.CheckOut();

            if (_pointFollower.TrySetPath(_tasker.BotTask.Task.Position) == false)
                throw new Exception("Invalid state");
        }
    }
}