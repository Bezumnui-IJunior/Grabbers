using StateMachines;

namespace View.Transitions
{
    public class BaseTooFewSelectedToBaseBusySelected : BaseBusySelectedTransition
    {
        public BaseTooFewSelectedToBaseBusySelected(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}