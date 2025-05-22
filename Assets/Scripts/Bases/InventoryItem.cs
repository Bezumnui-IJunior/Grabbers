using System;

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

        public void Add(int count)
        {
            PerformWithPositiveCheck(count, () => Count += count);
        }

        public void Remove(int count)
        {
            if (Count >= count)
                PerformWithPositiveCheck(count, () => Count -= count);
        }

        public void IncrementCount() =>
            ++Count;

        private void PerformWithPositiveCheck(int count, Action action)
        {
            if (count > 0)
                action();
        }
    }
}