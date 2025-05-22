using StateMachines;

namespace View.Transitions.FromBaseBusy
{
    public class BaseBusySelectedToIdle : NullBaseSelectedToIdleTransition
    {
        public BaseBusySelectedToIdle(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}