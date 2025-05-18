using UnityEngine;

namespace Bots
{
    public class BringItemTask : IBotTask
    {
        public BringItemTask(int itemId, Vector3 position)
        {
            ItemId = itemId;
            Position = position;
        }

        public int ItemId { get; }
        public Vector3 Position { get; }
    }
}