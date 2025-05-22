using UnityEngine;

namespace Bases
{
    public interface IBase
    {
        public Vector3 Center { get; }
        public IDropOffArea DropOffAreaOffArea { get; }
        public IMembersStorage MembersStorage { get; }

        public IWarehouse Warehouse { get; }
    }
}