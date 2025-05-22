using StateMachines;
using View.Transitions;

namespace View.States
{
    public class IdleState : State
    {
        private readonly IViewBaseSelector _selector;

        public IdleState(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger)
        {
            _selector = selector;
            AddTransition(new IdleToBaseSelected(stateChanger, selector));
            AddTransition(new IdleToBaseTooFewSelected(stateChanger, selector));
            AddTransition(new IdleToBaseBusySelected(stateChanger, selector));
        }

        public override void Enter()
        {
            _selector.UnSelect();
            _selector.Enable();
        }

        public override void Exit()
        {
            _selector.Disable();
        }
    }
}