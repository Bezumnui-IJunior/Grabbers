namespace Bases
{
    public class InventoryItem
    {
        public InventoryItem(string name)
        {
            Name = name;
            Count = 0;
        }

        public string Name { get; }
        public int Count { get; private set; }

        public void IncrementCount() =>
            ++Count;
    }
}