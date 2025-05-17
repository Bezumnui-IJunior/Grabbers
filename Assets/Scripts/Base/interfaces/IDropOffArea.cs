using System.Collections.Generic;

namespace Base
{
    public interface IDropOffArea
    {
        public void Load(IEnumerable<CollectedItem> items);
    }
}