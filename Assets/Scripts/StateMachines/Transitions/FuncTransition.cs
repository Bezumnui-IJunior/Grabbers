using System;

namespace StateMachines.Transitions
{
    public class FuncTransition<TState> : Transition<TState> where TState : State
    {
        private readonly Func<bool> _func;

        protected FuncTransition(IStateChanger stateChanger, Func<bool> func) : base(stateChanger)
        {
            _func = func;
        }

        protected override bool CanTransit() =>
            _func();
    }
}