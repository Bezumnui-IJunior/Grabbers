using Base;
using Bases.States;
using Misc;
using StateMachines;
using UnityEngine;

namespace Bases
{
    public class Base : MonoBehaviour, IBase, ICoroutineExecutor
    {
        [SerializeField] private MembersStorage _storage;
        [SerializeField] private TaskDispatcher _taskDispatcher;
        [SerializeField] private DropOffArea _drop;
        [SerializeField] private StateMachine _stateMachine;
        [SerializeField] private ItemsScanner _itemsScanner;
        [SerializeField] private float _scanDelaySeconds = 5;
        public Warehouse Warehouse { get; } = new Warehouse();

        public Vector3 Center => transform.position;
        public IDropOffArea DropOffArea => _drop;

        private void Start()
        {
            _stateMachine.ChangeState(_stateMachine.GetState<CollectingState>());
        }

        public void Init()
        {
            _drop.Init(Warehouse);
            _storage.Init(this);

            _stateMachine.AddState(typeof(CollectingState),
                new CollectingState(_stateMachine, _taskDispatcher, new BringTaskCreator(_taskDispatcher, _itemsScanner, new CooldownTimer(this, _scanDelaySeconds))));
        }
    }
}