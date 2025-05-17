namespace Bot
{
    public class BotTasker : IBotTasker
    {
        public Task Task { get; private set; }

        public void AssignTask(Task task)
        {
            Task = task;
        }
    }
}