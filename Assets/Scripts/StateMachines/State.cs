using System;
using System.Collections.Generic;

namespace StateMachines
{
    [Serializable]
    public abstract class State
    {
        private readonly IStateChanger _stateChanger;
        private readonly List<ITransition> _transitions = new List<ITransition>();

        protected State(IStateChanger stateChanger)
        {
            _stateChanger = stateChanger;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }

        public void Update()
        {
            foreach (ITransition transition in _transitions)
            {
                if (transition.TryTransit(out State nextState) == false)
                    continue;

                _stateChanger.ChangeState(nextState);

                return;
            }
        }

        protected void AddTransition(ITransition transition)
        {
            if (transition == null)
                throw new ArgumentNullException(nameof(transition), "is null");

            if (_transitions.Contains(transition))
                throw new ArgumentException($"{nameof(transition)}", $"already in {_transitions}");

            _transitions.Add(transition);
        }
    }
}