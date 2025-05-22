using StateMachines;

namespace View.Transitions
{
    public class BaseSelectedToBaseTooFewSelected : BaseTooFewTransition
    {
        public BaseSelectedToBaseTooFewSelected(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}