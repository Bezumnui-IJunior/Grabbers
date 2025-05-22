using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Spawners
{
    public abstract class Spawner<T> : MonoBehaviour where T : Object, ISpawnable<T>
    {
        [SerializeField] private T _prefab;
        [SerializeField] private int _poolSize;

        private ObjectPool<T> _pool;

        protected virtual void Awake()
        {
            _pool = new ObjectPool<T>(
                () => Instantiate(_prefab),
                OnGet,
                OnRelease,
                spawnable => spawnable.Destroy(),
                true,
                _poolSize,
                _poolSize
            );
        }

        protected bool IsOverflow() =>
            _pool.CountActive >= _poolSize;

        public T InstantiateObject() =>
            _pool.Get();

        private void OnRelease(T spawnable)
        {
            spawnable.Dying -= _pool.Release;
            spawnable.TurnOff();
        }

        private void OnGet(T spawnable)
        {
            spawnable.TurnOn();
            spawnable.Dying += _pool.Release;
        }
    }
}