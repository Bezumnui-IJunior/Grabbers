using System.Collections.Generic;
using Bots;
using UnityEngine;

namespace Bases
{
    public class TaskDispatcher : MonoBehaviour
    {
        [SerializeField] private MembersStorage _storage;
        private readonly Queue<TypedTask> _tasks = new Queue<TypedTask>();
        private int Count => _tasks.Count;

        private void Update()
        {
            if (Count == 0)
                return;

            foreach (TaskAcceptor bot in _storage.BotsReady)
            {
                if (bot.CanAcceptTask() == false)
                    continue;

                TypedTask task = GetTask();
                bot.AssignTask(task);
                _storage.OccupyBot(bot);

                return;
            }
        }

        public void AddTask(TypedTask task) =>
            _tasks.Enqueue(task);

        private TypedTask GetTask() =>
            _tasks.Dequeue();

        public void Enable() =>
            enabled = true;

        public void Disable() =>
            enabled = false;
    }
}