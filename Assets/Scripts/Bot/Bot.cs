using Base;
using UnityEngine;

namespace Bot
{
    public class Bot : MonoBehaviour
    {
        [SerializeField] private StateMachine _stateMachine;
        [SerializeField] private TaskAcceptor _taskAcceptor;
        [SerializeField] private BaseMember _member;

        private readonly Inventory _inventory = new Inventory();
        private readonly BotTasker _tasker = new BotTasker();

        public TaskAcceptor TaskAcceptor => _taskAcceptor;

        private void Awake()
        {
            _stateMachine.Init(_tasker, _inventory);
        }

        public void ChangeBase(IBase @base)
        {
            _member.SetBase(@base);
        }
    }
}