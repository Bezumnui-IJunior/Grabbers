using StateMachines;

namespace View.Transitions
{
    public class IdleToBaseBusySelected : BaseBusySelectedTransition
    {
        public IdleToBaseBusySelected(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}