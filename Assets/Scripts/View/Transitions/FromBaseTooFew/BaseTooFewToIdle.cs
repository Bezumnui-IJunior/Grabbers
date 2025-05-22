using StateMachines;

namespace View.Transitions
{
    public class BaseTooFewToIdle : NullBaseSelectedToIdleTransition
    {
        public BaseTooFewToIdle(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}