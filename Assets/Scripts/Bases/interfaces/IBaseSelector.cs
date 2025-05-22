namespace Bases
{
    public interface IBaseSelector
    {
        public IBaseCreator BaseCreator { get; }
        public IMembersStorage MembersStorage { get; }
        public IWarehouse Warehouse { get; }

        void Select();
        void UnSelect();
    }
}