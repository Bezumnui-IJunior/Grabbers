using UnityEngine;

namespace Bot.States
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private StateMachine _stateMachine;

        public void Occupy() =>
            enabled = true;

        public void Exit() =>
            enabled = false;

        protected void ChangeState<TState>() where TState : IState =>
            _stateMachine.ChangeState<TState>();
    }
}