using UnityEngine;

namespace Bot
{
    public class Bot : MonoBehaviour
    {
        [SerializeField] private StateMachine _stateMachine;
        private readonly Inventory _inventory = new Inventory();
        private readonly BotTasker _tasker = new BotTasker();

        private void Awake()
        {
            _stateMachine.Init(_tasker, _inventory);
        }
    }
}