using Bases;
using Bots;
using UnityEngine;

namespace Spawners
{
    public class BotFactory : MonoBehaviour
    {
        [SerializeField] private Bots.Bot _prefab;
        [SerializeField] private BaseBuilder _baseBuilder;

        public void CreateBot(IMembersStorage storage)
        {
            Bots.Bot bot = Instantiate(_prefab);
            bot.Init(storage, _baseBuilder);
            bot.transform.position = storage.SpawnPoint;
        }
    }
}