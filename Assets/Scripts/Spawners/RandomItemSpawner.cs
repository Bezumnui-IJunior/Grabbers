using System;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawners
{
    public class RandomItemSpawner : MonoBehaviour
    {
        [SerializeField] private BoxItemSpawner _boxItemSpawner;
        [SerializeField] private SphereItemSpawner _sphereItemSpawner;
        [SerializeField] private NavMeshSurface _surface;
        [SerializeField] private float _yPlane = 1;
        private NavmeshPointGenerator _pointGenerator;
        private List<IItemSpawner> _spawners;

        public event Action<Item> Spawned;

        private void Awake()
        {
            _pointGenerator = new NavmeshPointGenerator(_surface);

            _spawners = new List<IItemSpawner>
            {
                _boxItemSpawner,
                _sphereItemSpawner,
            };
        }

        [ContextMenu("SpawnItem")]
        public void SpawnItem()
        {
            if (_pointGenerator.TryGetPointOnSurface(out Vector3 position) == false)
                return;

            Item item = GetRandomSpawner().InstantiateObject();
            position.y = _yPlane;
            item.transform.position = position;
            Spawned?.Invoke(item);
        }

        private IItemSpawner GetRandomSpawner() =>
            _spawners[Random.Range(0, _spawners.Count)];
    }
}