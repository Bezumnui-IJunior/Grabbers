using UnityEngine;

namespace Bot
{
    public class Task
    {
        public Task(string itemName, Vector3 position)
        {
            ItemName = itemName;
            Position = position;
        }

        public string ItemName { get; }
        public Vector3 Position { get; }
    }
}