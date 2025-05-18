using UnityEngine;

namespace Base
{
    public interface IBase
    {
        public Vector3 Center { get; }
        public IDropOffArea DropOffArea { get; }
    }
}