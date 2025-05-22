using Flags;

namespace Bases
{
    public interface IBaseCreator
    {
        public bool HasScheduledTask { get; }
        public IFlag Flag { get; }
        public void ScheduleTask(Flag flag);
        public void OnBuilt();
    }
}