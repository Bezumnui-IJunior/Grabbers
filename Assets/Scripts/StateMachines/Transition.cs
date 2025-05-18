namespace StateMachines
{
    public abstract class Transition<TState> : ITransition where TState : State
    {
        private readonly IStateChanger _stateChanger;

        protected Transition(IStateChanger stateChanger)
        {
            _stateChanger = stateChanger;
        }

        public bool TryTransit(out State nextState)
        {
            if (CanTransit() == false)
            {
                nextState = null;

                return false;
            }

            nextState = _stateChanger.GetState<TState>();

            return true;
        }

        protected abstract bool CanTransit();
    }
}