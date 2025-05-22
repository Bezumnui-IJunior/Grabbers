using Bases;
using Bots.Transitions;
using StateMachines;

namespace Bots.States
{
    public class BuildingBaseState : State
    {
        private readonly BaseBuilder _baseBuilder;
        private readonly BaseMember _member;
        private readonly IBotTasker _tasker;

        public BuildingBaseState(IStateChanger stateChanger, BaseBuilder baseBuilder, IBotTasker tasker, BaseMember member) : base(stateChanger)
        {
            _baseBuilder = baseBuilder;
            _tasker = tasker;
            _member = member;
            AddTransition(new BuildingBaseToIdle(stateChanger));
        }

        public override void Enter()
        {
            _tasker.BotTask.GetBuildBaseTask().Flag.Remove();
            Base newBase = _baseBuilder.BuildNewBase(_member.transform.position);
            _member.SetBase(newBase.MembersStorage);
        }
    }
}