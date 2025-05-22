using Bots;
using Misc;
using UnityEngine;

namespace Bases
{
    public class TaskDispatcher : MonoBehaviour
    {
        [SerializeField] private MembersStorage _storage;

        private readonly PriorityQueue<TypedTask> _tasks = new PriorityQueue<TypedTask>();

        private void Update()
        {
            AssignTasks();
        }

        private void AssignTasks()
        {
            if (_tasks.Count == 0)
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
            _tasks.Enqueue(task, (int)task.Type);

        private TypedTask GetTask() =>
            _tasks.Dequeue();
    }
}