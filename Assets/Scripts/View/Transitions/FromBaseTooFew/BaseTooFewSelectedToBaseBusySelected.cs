using StateMachines;

namespace View.Transitions
{
    public class BaseTooFewSelectedToBaseBusySelected : BaseTooFewTransition
    {
        public BaseTooFewSelectedToBaseBusySelected(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}