using Bots;
using Misc;
using TypedTask = Bots.TypedTask;

namespace Bases
{
    public class BringTaskCreator
    {
        private readonly ItemsScanner _itemsScanner;
        private readonly TaskDispatcher _taskDispatcher;
        private readonly CooldownTimer _timer;

        public BringTaskCreator(TaskDispatcher taskDispatcher, ItemsScanner itemsScanner, CooldownTimer timer)
        {
            _taskDispatcher = taskDispatcher;
            _itemsScanner = itemsScanner;
            _timer = timer;
        }

        public void Enable()
        {
            _timer.Start();
            _timer.Freed += OnTimerFreed;
        }

        public void Disable()
        {
            _timer.Stop();
            _timer.Freed -= OnTimerFreed;
        }

        private void OnTimerFreed()
        {
            foreach (Item item in _itemsScanner.GiveFound())
                _taskDispatcher.AddTask(new TypedTask(new BringItemTask(item.UniqueID, item.Position), BotTasks.BringItem));

            _timer.Start();
        }
    }
}