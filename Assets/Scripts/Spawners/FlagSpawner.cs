using Flags;
using UnityEngine;

namespace Spawners
{
    public class FlagSpawner : Spawner<Flag>
    {
        [SerializeField] private float _yOffset = 0.5f;

        public Flag Spawn(Vector3 position)
        {
            Flag flag = InstantiateObject();
            position.y += _yOffset;
            flag.Init(position);

            return flag;
        }
    }
}