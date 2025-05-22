using System;
using Flags;

namespace Bases
{
    public class BaseCreator : IBaseCreator
    {
        public IFlag Flag { get; private set; }
        public bool HasScheduledTask { get; private set; }

        public void ScheduleTask(Flag flag)
        {
            if (HasScheduledTask)
                throw new Exception("Base creator has already a task");

            Flag = flag;
            HasScheduledTask = true;
        }

        public void OnBuilt()
        {
            if (HasScheduledTask == false)
                throw new Exception("Base creator already has scheduled task.");

            HasScheduledTask = false;
        }
    }
}