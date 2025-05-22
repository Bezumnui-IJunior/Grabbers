using Bots;
using UnityEngine;

namespace Bases
{
    public interface IMembersStorage
    {
        public int Count { get; }
        public Vector3 SpawnPoint { get; }

        public IDropOffArea DropOffArea { get; }
        public void CheckOut(IBaseMember member);
        public void CheckIn(IBaseMember member);
    }
}