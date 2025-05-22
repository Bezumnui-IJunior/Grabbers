using Items;
using UnityEngine;

namespace Bots
{
    public class BringItemTask : IBotTask
    {
        public readonly Item Item;

        public BringItemTask(Item item, Vector3 position)
        {
            Item = item;
            Position = position;
        }

        public Vector3 Position { get; }
    }
}