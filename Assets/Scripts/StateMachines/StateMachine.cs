using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachines
{
    public class StateMachine : MonoBehaviour, IStateChanger
    {
        private readonly Dictionary<Type, State> _states = new Dictionary<Type, State>();
        private State _currentState;

        private void Update()
        {
            _currentState?.Update();
        }

        public void ChangeState(State state)
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public State GetState<TState>() where TState : State
        {
            if (_states.TryGetValue(typeof(TState), out State state) == false)
                throw new ArgumentException($"Please update dict. No {typeof(TState)} there.");

            return state;
        }

        public void AddState(Type key, State state)
        {
            _states.Add(key, state);
        }
    }
}