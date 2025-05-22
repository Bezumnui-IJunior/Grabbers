using StateMachines;

namespace View.Transitions
{
    public class BaseTooFewSelectedToIdle : NullBaseSelectedToIdleTransition
    {
        public BaseTooFewSelectedToIdle(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}