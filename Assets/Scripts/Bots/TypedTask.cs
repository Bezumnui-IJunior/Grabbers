using System;

namespace Bots
{
    public class TypedTask
    {
        public readonly IBotTask Task;
        public readonly BotTasks Type;

        public TypedTask(IBotTask task, BotTasks type)
        {
            Task = task;
            Type = type;
        }

        public BringItemTask GetBringItemTask() =>
            GetTask<BringItemTask>(BotTasks.BringItem);

        public BuildBaseTask GetBuildBaseTask() =>
            GetTask<BuildBaseTask>(BotTasks.BuildNewBase);

        private T GetTask<T>(BotTasks type)
        {
            if (Type != type)
                throw new TypeAccessException(
                    $"Collecting state must have {type} task. Got {Type} instead");

            return (T)Task;
        }
    }
}