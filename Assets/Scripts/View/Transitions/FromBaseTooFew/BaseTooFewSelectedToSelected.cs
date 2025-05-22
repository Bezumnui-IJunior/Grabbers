using System;
using StateMachines;
using View.States;

namespace View.Transitions
{
    public class BaseTooFewSelectedToSelected : BaseSelectedTransition<BaseSelectedState>
    {
        public BaseTooFewSelectedToSelected(IStateChanger stateChanger, IViewBaseSelector selector, Predicate<int> predicate) : base(stateChanger, selector, predicate) { }
    }
}