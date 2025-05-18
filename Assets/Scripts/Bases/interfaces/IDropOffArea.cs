using System.Collections.Generic;

namespace Bases
{
    public interface IDropOffArea
    {
        public void Load(IEnumerable<CollectedItem> items);
    }
}