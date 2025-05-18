using StateMachines;

namespace Bots.Transitions
{
    public class TransitionOnBased<TState> : Transition<TState> where TState : State
    {
        private readonly IBaseConsistencyProvider _consistencyProvider;

        public TransitionOnBased(IStateChanger stateChanger, IBaseConsistencyProvider consistencyProvider) : base(
            stateChanger)
        {
            _consistencyProvider = consistencyProvider;
        }

        protected override bool CanTransit() =>
            _consistencyProvider.IsInsideBase;
    }
}