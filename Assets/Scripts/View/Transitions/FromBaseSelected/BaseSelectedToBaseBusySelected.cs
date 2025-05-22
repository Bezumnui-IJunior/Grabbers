using StateMachines;

namespace View.Transitions
{
    public class BaseSelectedToBaseBusySelected : BaseBusySelectedTransition
    {
        public BaseSelectedToBaseBusySelected(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}