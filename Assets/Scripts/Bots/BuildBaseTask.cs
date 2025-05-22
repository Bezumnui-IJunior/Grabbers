using Flags;
using UnityEngine;

namespace Bots
{
    public class BuildBaseTask : IBotTask
    {
        public BuildBaseTask(IFlag flag)
        {
            Flag = flag;
        }

        public IFlag Flag { get; }
        public Vector3 Position => Flag.Position;
    }
}