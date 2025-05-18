using Base;
using Bot;
using Bots.States;
using StateMachines;
using UnityEngine;

namespace Bots
{
    public class Bot : MonoBehaviour, ICoroutineExecutor
    {
        [SerializeField] private StateMachine _stateMachine;
        [SerializeField] private TaskAcceptor _taskAcceptor;
        [SerializeField] private BaseMember _member;
        [SerializeField] private PointFollower _pointFollower;
        [SerializeField] private ItemDetector _itemDetector;
        [SerializeField] private DropOffer _dropOffer;
        [SerializeField] private float _pickupSeconds;

        public TaskAcceptor TaskAcceptor => _taskAcceptor;

        private void Start()
        {
            _stateMachine.ChangeState(_stateMachine.GetState<IdleState>());
        }

        public void ChangeBase(IBase @base)
        {
            _member.SetBase(@base);
        }

        public void Init()
        {
            Inventory inventory = new Inventory();
            BotTasker tasker = new BotTasker();
            _taskAcceptor.Init(tasker);

            new StateMachineInitializer().InitializeStateMachine(
                _stateMachine,
                _taskAcceptor,
                tasker,
                _pointFollower,
                _itemDetector,
                inventory,
                this,
                _pickupSeconds,
                _member,
                _dropOffer
            );
        }
    }
}