using System;
using System.Collections.Generic;
using Bot.States;
using UnityEngine;

namespace Bot
{
    public class StateMachine : MonoBehaviour, IStateMachine
    {
        [SerializeField] private IdleState _idleState;
        [SerializeField] private MoveToItem _movingToItemState;
        [SerializeField] private CollectingState _collectingState;
        [SerializeField] private ReturnState _returnState;
        [SerializeField] private DropOffState _dropOffState;
        private State _currentState;
        private Dictionary<Type, State> _states;

        private BotTasker _tasker;

        private void Start()
        {
            ChangeState<IIdleState>();
        }

        public void ChangeState<TState>() where TState : IState
        {
            if (_states.TryGetValue(typeof(TState), out State value) == false)
                throw new ArgumentException($"Unexpected argument {typeof(TState)}. Update {nameof(_currentState)}.");

            _currentState?.Exit();
            _currentState = value;
            _currentState.Occupy();
        }

        public void Init(BotTasker tasker, Inventory inventory)
        {
            _tasker = tasker;

            _idleState.Init(_tasker);
            _movingToItemState.Init(_tasker);
            _collectingState.Init(_tasker, inventory);
            _dropOffState.Init(inventory);

            _states = new Dictionary<Type, State>
            {
                [typeof(IIdleState)] = _idleState,
                [typeof(IMoveToItemState)] = _movingToItemState,
                [typeof(ICollectingState)] = _collectingState,
                [typeof(IReturnState)] = _returnState,
                [typeof(IDropOffState)] = _dropOffState,
            };
        }
    }
}