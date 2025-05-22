using StateMachines;
using View.States;

namespace View.Transitions
{
    public class BaseTooFewTransition : BaseSelectedTransition<BaseTooFewSelectedState>
    {
        public BaseTooFewTransition(IStateChanger stateChanger, IViewBaseSelector selector)
            : base(stateChanger, selector, count => count <= 1) { }
    }
}