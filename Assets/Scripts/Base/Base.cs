using System.Collections.Generic;
using Bot;
using Spawners;
using UnityEngine;

namespace Base
{
    public class Base : MonoBehaviour, IBase
    {
        [SerializeField] private RandomItemSpawner _itemSpawner;
        [SerializeField] private List<Bot.Bot> _members;
        [SerializeField] private DropOffArea _drop;

        private readonly List<TaskAcceptor> _membersIdle = new List<TaskAcceptor>();
        private readonly List<Task> _tasks = new List<Task>();

        public Warehouse Warehouse { get; } = new Warehouse();

        public Vector3 Center => transform.position;
        public IDropOffArea DropOffArea => _drop;

        private void Awake()
        {
            _drop.Init(Warehouse);
        }

        private void Update()
        {
            if (_tasks.Count == 0)
                return;

            foreach (TaskAcceptor taskAcceptor in _membersIdle)
            {
                if (taskAcceptor.TryAcceptTask(_tasks[0]) == false)
                    continue;

                _tasks.RemoveAt(0);
                _membersIdle.Remove(taskAcceptor);

                return;
            }
        }

        private void OnEnable()
        {
            _itemSpawner.Spawned += OnItemSpawned;

            foreach (Bot.Bot bot in _members)
            {
                bot.ChangeBase(this);
                bot.TaskAcceptor.GotReady += OnGotReady;
            }
        }

        private void OnDisable()
        {
            _itemSpawner.Spawned -= OnItemSpawned;

            foreach (Bot.Bot bot in _members)
                bot.TaskAcceptor.GotReady -= OnGotReady;
        }

        private void OnGotReady(TaskAcceptor bot)
        {
            _membersIdle.Add(bot);
            _itemSpawner.SpawnItem();
        }

        private void OnItemSpawned(Item item)
        {
            _tasks.Add(new Task(item.UniqueID, item.Position));
        }
    }
}