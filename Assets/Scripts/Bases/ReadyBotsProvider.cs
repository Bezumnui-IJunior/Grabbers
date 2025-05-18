using System.Collections.Generic;
using Bots;

namespace Bases
{
    public interface IReadyBotsProvider
    {
        public IEnumerable<TaskAcceptor> BotsReady { get; }

        public void OccupyBot(TaskAcceptor bot);
    }
}