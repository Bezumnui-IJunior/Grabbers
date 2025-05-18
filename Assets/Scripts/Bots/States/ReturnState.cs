using System;
using Bot;
using Bots.Transitions;
using StateMachines;

namespace Bots.States
{
    public class ReturnState : State
    {
        private readonly BaseMember _baseMember;
        private readonly PointFollower _pointFollower;

        public ReturnState(IStateChanger stateChanger, BaseMember baseMember, IBaseConsistencyProvider dropOffer,
            PointFollower pointFollower) : base(stateChanger)
        {
            _baseMember = baseMember;
            _pointFollower = pointFollower;
            AddTransition(new TransitionOnBased<DropOffState>(stateChanger, dropOffer));
        }

        public override void Enter()
        {
            if (_pointFollower.TrySetPath(_baseMember.Base.Center) == false)
                throw new Exception("Unexpected bot position. Could not reach the base");
        }

        public override void Exit()
        {
            _pointFollower.Stop();
        }
    }
}