using UnityEngine;

namespace Flags
{
    public interface IFlag
    {
        public Vector3 Position { get; }
        public void Remove();
    }
}