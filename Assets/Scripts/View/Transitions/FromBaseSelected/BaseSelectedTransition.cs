using System;
using StateMachines;

namespace View.Transitions
{
    public abstract class BaseSelectedTransition<T> : Transition<T> where T : State
    {
        private readonly Predicate<int> _predicate;
        private readonly IViewBaseSelector _selector;

        protected BaseSelectedTransition(IStateChanger stateChanger, IViewBaseSelector selector, Predicate<int> predicate) : base(stateChanger)
        {
            _selector = selector;
            _predicate = predicate;
        }

        protected override bool CanTransit() =>
            _selector.Selected != null &&
            _selector.Selected.BaseCreator.HasScheduledTask == false &&
            _predicate(_selector.Selected.MembersStorage.Count);
    }
}