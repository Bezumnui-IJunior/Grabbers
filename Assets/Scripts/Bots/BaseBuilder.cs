using Bases;
using Spawners;
using UnityEngine;

namespace Bots
{
    public class BaseBuilder : MonoBehaviour
    {
        [SerializeField] private Base _basePrefab;
        [SerializeField] private BotFactory _botFactory; // ReSharper disable Unity.PerformanceAnalysis
        public Base BuildNewBase(Vector3 position)
        {
            Base newBase = Instantiate(_basePrefab);
            newBase.transform.position = position;
            newBase.Init(_botFactory);

            return newBase;
        }
    }
}