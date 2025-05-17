using UnityEngine;

namespace Bot
{
    public class Task
    {
        public Task(int id, Vector3 position)
        {
            Id = id;
            Position = position;
        }

        public int Id { get; }
        public Vector3 Position { get; }
    }
}