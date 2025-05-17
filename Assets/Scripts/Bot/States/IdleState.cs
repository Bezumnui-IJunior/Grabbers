using UnityEngine;

namespace Bot.States
{
    public class IdleState : State, IIdleState
    {
        [SerializeField] private TaskAcceptor _taskAcceptor;

        private BotTasker _tasker;

        private void OnEnable()
        {
            _taskAcceptor.GetReady();
            _taskAcceptor.TaskReceived += OnTaskReceived;
        }

        private void OnDisable()
        {
            _taskAcceptor.TaskReceived -= OnTaskReceived;
        }

        private void OnTaskReceived(Task task)
        {
            _tasker.AssignTask(task);
            ChangeState<IMoveToItemState>();
        }

        public void Init(BotTasker tasker)
        {
            _tasker = tasker;
        }
    }
}