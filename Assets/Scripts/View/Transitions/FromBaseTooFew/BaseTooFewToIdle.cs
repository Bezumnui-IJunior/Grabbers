using StateMachines;

namespace View.Transitions.FromBaseTooFew
{
    public class BaseTooFewToIdle : NullBaseSelectedToIdleTransition
    {
        public BaseTooFewToIdle(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}