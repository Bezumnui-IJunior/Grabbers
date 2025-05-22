using StateMachines;

namespace View.Transitions.FromBaseTooFew
{
    public class BaseToFewSelectedToBaseBusySelected : BaseBusySelectedTransition
    {
        public BaseToFewSelectedToBaseBusySelected(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}