namespace Bots
{
    public interface IBotTasker
    {
        public TypedTask BotTask { get; }
        public bool HasTask { get; }
    }
}