using System.Collections.Generic;
using Items;

namespace Bases
{
    public interface IDropOffArea
    {
        public void Load(IEnumerable<CollectedItem> items);
    }
}