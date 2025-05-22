using Bases;

namespace View
{
    public interface IViewBaseSelector
    {
        public IBaseSelector Selected { get; }
        public void UnSelect();
        void Enable();
        void Disable();
    }
}