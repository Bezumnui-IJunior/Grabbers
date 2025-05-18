using Misc;
using StateMachines;

namespace Bots.Transitions
{
    public class DelayedTransition<TState> : Transition<TState> where TState : State
    {
        private readonly CooldownTimer _timer;
        private float _targetTime;

        public DelayedTransition(IStateChanger stateChanger, CooldownTimer timer) : base(stateChanger)
        {
            _timer = timer;
        }

        protected override bool CanTransit() =>
            _timer.IsFree;
    }
}