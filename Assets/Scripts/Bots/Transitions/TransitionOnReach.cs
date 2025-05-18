using StateMachines;

namespace Bots.Transitions
{
    public class TransitionOnReach<TState> : Transition<TState> where TState : State
    {
        private readonly PointFollower _pointFollower;

        public TransitionOnReach(IStateChanger stateChanger, PointFollower pointFollower) : base(stateChanger)
        {
            _pointFollower = pointFollower;
        }

        protected override bool CanTransit() =>
            _pointFollower.IsBusy == false;
    }
}