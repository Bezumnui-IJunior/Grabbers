namespace Bots
{
    public class BotTasker : IBotTasker
    {
        public TypedTask BotTask { get; private set; }

        public bool HasTask { get; private set; }

        public void AssignTask(TypedTask bringItemTask)
        {
            BotTask = bringItemTask;
            HasTask = true;
        }

        public void ClearTask()
        {
            BotTask = null;
            HasTask = false;
        }
    }
}