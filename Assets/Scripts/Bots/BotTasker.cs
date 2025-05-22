namespace Bots
{
    public class BotTasker : IBotTasker
    {
        public TypedTask BotTask { get; private set; }

        public bool HasTask { get; private set; }

        public void AssignTask(TypedTask task)
        {
            BotTask = task;
            HasTask = true;
        }

        public void ClearTask()
        {
            BotTask = null;
            HasTask = false;
        }
    }
}