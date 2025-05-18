using System;

namespace Bots
{
    public class TypedTask
    {
        private readonly IBotTask _task;
        public readonly BotTasks Type;

        public TypedTask(IBotTask task, BotTasks type)
        {
            _task = task;
            Type = type;
        }

        public BringItemTask GetBringItemTask() =>
            GetTask<BringItemTask>(BotTasks.BringItem);

        private T GetTask<T>(BotTasks type)
        {
            if (Type != type)
                throw new TypeAccessException(
                    $"Collecting state must have {type} task. Got {Type} instead");

            return (T)_task;
        }
    }
}