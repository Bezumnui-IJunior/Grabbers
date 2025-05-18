using System;
using UnityEngine;

namespace Bots
{
    public class TaskAcceptor : MonoBehaviour
    {
        private BotTasker _tasker;
        public event Action<TaskAcceptor> GotReady;

        public void AssignTask(TypedTask task)
        {
            _tasker.AssignTask(task);
        }

        public void Init(BotTasker tasker)
        {
            _tasker = tasker;
        }

        public bool CanAcceptTask() =>
            _tasker.HasTask == false;

        public void GetReady()
        {
            _tasker.ClearTask();
            GotReady?.Invoke(this);
        }
    }
}