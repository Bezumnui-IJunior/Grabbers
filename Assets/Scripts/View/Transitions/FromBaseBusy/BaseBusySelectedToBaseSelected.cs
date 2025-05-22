using StateMachines;

namespace View.Transitions.FromBaseBusy
{
    public class BaseBusySelectedToBaseSelected : BaseSelectedCorrectTransition
    {
        public BaseBusySelectedToBaseSelected(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}