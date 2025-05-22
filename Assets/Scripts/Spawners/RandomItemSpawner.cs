using System.Collections.Generic;
using Items;
using Misc;
using Unity.AI.Navigation;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class RandomItemSpawner : MonoBehaviour, ICoroutineExecutor
    {
        [SerializeField] private BoxItemSpawner _boxItemSpawner;
        [SerializeField] private SphereItemSpawner _sphereItemSpawner;
        [SerializeField] private NavMeshSurface _surface;
        [SerializeField] private float _yPlane = 1;
        [SerializeField] private float _spawnDelaySeconds;
        private NavmeshPointGenerator _pointGenerator;
        private List<IItemSpawner> _spawners;
        private CooldownTimer _timer;

        private void Awake()
        {
            _timer = new CooldownTimer(this, _spawnDelaySeconds);

            _pointGenerator = new NavmeshPointGenerator(_surface);

            _spawners = new List<IItemSpawner>
            {
                _boxItemSpawner,
                _sphereItemSpawner,
            };
        }

        private void OnEnable()
        {
            _timer.Freed += SpawnWithTimer;
            _timer.Start();
        }

        private void OnDisable()
        {
            _timer.Freed -= SpawnWithTimer;
        }

        private void SpawnWithTimer()
        {
            SpawnItem();
            _timer.Start();
        }

        [ContextMenu("SpawnItem")]
        public void SpawnItem()
        {
            if (_pointGenerator.TryGetPointOnSurface(out Vector3 position) == false)
                return;

            Item item = GetRandomSpawner().InstantiateObject();
            position.y = _yPlane;
            item.transform.position = position;
        }

        private IItemSpawner GetRandomSpawner() =>
            _spawners[Random.Range(0, _spawners.Count)];
    }
}