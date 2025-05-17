using System.Collections.Generic;
using Bot;
using Spawners;
using UnityEngine;

namespace Base
{
    public class Base : MonoBehaviour
    {
        [SerializeField] private RandomItemSpawner _itemSpawner;
        [SerializeField] private List<TaskAcceptor> _bots;
        [SerializeField] private DropOffArea _drop;

        private readonly List<TaskAcceptor> _botsReady = new List<TaskAcceptor>();
        private readonly List<Task> _tasks = new List<Task>();

        public Warehouse Warehouse { get; } = new Warehouse();

        private void Awake()
        {
            _drop.Init(Warehouse);
        }

        private void Update()
        {
            if (_tasks.Count == 0)
                return;

            foreach (TaskAcceptor bot in _botsReady)
            {
                if (bot.TryAcceptTask(_tasks[0]) == false)
                    continue;

                _tasks.RemoveAt(0);
                _botsReady.Remove(bot);

                return;
            }
        }

        private void OnEnable()
        {
            _itemSpawner.Spawned += OnItemSpawned;

            foreach (TaskAcceptor bot in _bots)
                bot.GotReady += OnGotReady;
        }

        private void OnDisable()
        {
            _itemSpawner.Spawned -= OnItemSpawned;

            foreach (TaskAcceptor bot in _bots)
                bot.GotReady -= OnGotReady;
        }

        private void OnGotReady(TaskAcceptor bot)
        {
            _botsReady.Add(bot);
            _itemSpawner.SpawnItem();
        }

        private void OnItemSpawned(Item item)
        {
            _tasks.Add(new Task(item.Name, item.Position));
        }
    }
}