using StateMachines;
using View.States;

namespace View.Transitions
{
    public abstract class BaseBusySelectedTransition : Transition<BaseBusySelectedState>
    {
        private readonly IViewBaseSelector _selector;

        protected BaseBusySelectedTransition(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger)
        {
            _selector = selector;
        }

        protected override bool CanTransit() =>
            _selector.Selected != null &&
            _selector.Selected.BaseCreator.HasScheduledTask;
    }
}