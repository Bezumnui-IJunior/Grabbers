using Bases;

namespace Bots
{
    public interface IBaseMember
    {
        public IMembersStorage MembersStorage { get; }
        public TaskAcceptor TaskAcceptor { get; }
        public void SetBase(IMembersStorage storage);
        public void CheckOut();
    }
}