using System;
using UnityEngine;

namespace Bot
{
    public class TaskAcceptor : MonoBehaviour
    {
        public event Action<Task> TaskReceived;

        public event Action<TaskAcceptor> GotReady;

        public bool TryAcceptTask(Task task)
        {
            if (TaskReceived == null)
                return false;

            TaskReceived.Invoke(task);

            return true;
        }

        public void GetReady()
        {
            GotReady?.Invoke(this);
        }
    }
}