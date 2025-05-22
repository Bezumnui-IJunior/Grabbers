using StateMachines;

namespace View.Transitions
{
    public class IdleToBaseTooFewSelected : BaseTooFewTransition
    {
        public IdleToBaseTooFewSelected(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}