using StateMachines;
using View.States;

namespace View.Transitions
{
    public abstract class BaseSelectedCorrectTransition : BaseSelectedTransition<BaseSelectedState>
    {
        protected BaseSelectedCorrectTransition(IStateChanger stateChanger, IViewBaseSelector selector)
            : base(stateChanger, selector, count => count > 1) { }
    }
}