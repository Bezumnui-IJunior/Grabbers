namespace StateMachines.Transitions
{
    public class ImmediateTransition<TState> : Transition<TState> where TState : State
    {
        protected ImmediateTransition(IStateChanger stateChanger) : base(stateChanger) { }

        protected override bool CanTransit() =>
            true;
    }
}