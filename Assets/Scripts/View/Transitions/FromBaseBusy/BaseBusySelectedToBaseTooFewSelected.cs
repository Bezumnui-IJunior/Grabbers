using StateMachines;

namespace View.Transitions.FromBaseBusy
{
    public class BaseBusySelectedToBaseTooFewSelected : BaseTooFewTransition
    {
        public BaseBusySelectedToBaseTooFewSelected(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}