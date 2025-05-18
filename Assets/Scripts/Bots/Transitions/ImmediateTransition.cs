using StateMachines;

namespace Bots.Transitions
{
    public class ImmediateTransition<TState> : Transition<TState> where TState : State
    {
        public ImmediateTransition(IStateChanger stateChanger) : base(stateChanger) { }

        protected override bool CanTransit() =>
            true;
    }
}