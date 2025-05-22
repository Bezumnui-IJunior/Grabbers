using Bases.States;
using Misc;
using Spawners;
using StateMachines;
using UnityEngine;

namespace Bases
{
    public class Base : MonoBehaviour, IBase, ICoroutineExecutor
    {
        [SerializeField] private MembersStorage _storage;
        [SerializeField] private TaskDispatcher _taskDispatcher;
        [SerializeField] private DropOffArea _dropOffArea;
        [SerializeField] private StateMachine _stateMachine;
        [SerializeField] private BaseSelector _baseSelector;
        [SerializeField] private ItemsScanner _itemsScanner;
        [SerializeField] private BotFactory _botFactory;
        [SerializeField] private float _scanDelaySeconds = 5;
        [SerializeField] private int _priceForBot = 3;
        [SerializeField] private int _priceForBase = 5;

        private readonly Warehouse _warehouse = new Warehouse();

        public IWarehouse Warehouse => _warehouse;

        public Vector3 Center => transform.position;
        public IDropOffArea DropOffAreaOffArea => _dropOffArea;
        public IMembersStorage MembersStorage => _storage;

        private void Start()
        {
            _stateMachine.ChangeState(_stateMachine.GetState<CollectingState>());
        }

        public void Init(BotFactory botFactory)
        {
            _botFactory = botFactory;

            Init();
        }

        public void Init()
        {
            BaseCreator baseCreator = new BaseCreator();
            BringTaskCreator taskCreator = new BringTaskCreator(_taskDispatcher, _itemsScanner, new CooldownTimer(this, _scanDelaySeconds));
            _dropOffArea.Init(_warehouse);
            _baseSelector.Init(baseCreator, MembersStorage, _warehouse);
            _storage.Init(_dropOffArea);

            _stateMachine.AddState(typeof(CollectingState), new CollectingState(_stateMachine, _taskDispatcher, taskCreator, _priceForBot, _warehouse, baseCreator));
            _stateMachine.AddState(typeof(CreateNewBotState), new CreateNewBotState(_stateMachine, _botFactory, Warehouse, _priceForBot, MembersStorage));
            _stateMachine.AddState(typeof(EarningForBaseState), new EarningForBaseState(_stateMachine, _taskDispatcher, baseCreator, taskCreator, _priceForBase, _warehouse));
        }
    }
}