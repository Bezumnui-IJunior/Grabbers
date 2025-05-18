namespace StateMachines
{
    public interface IStateChanger
    {
        public State GetState<TState>() where TState : State;
        public void ChangeState(State state);
    }
}