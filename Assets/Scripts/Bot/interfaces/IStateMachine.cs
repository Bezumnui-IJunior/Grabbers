using Bot.States;

namespace Bot
{
    public interface IStateMachine
    {
        public void ChangeState<TState>() where TState : IState;
    }
}