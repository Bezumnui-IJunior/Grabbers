using StateMachines;
using View.States;

namespace View.Transitions
{
    public abstract class NullBaseSelectedToIdleTransition : Transition<IdleState>
    {
        private readonly IViewBaseSelector _selector;

        protected NullBaseSelectedToIdleTransition(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger)
        {
            _selector = selector;
        }

        protected override bool CanTransit() =>
            _selector.Selected == null;
    }
}