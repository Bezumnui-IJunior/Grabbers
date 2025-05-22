using StateMachines;
using View.Transitions.FromBaseBusy;

namespace View.States
{
    public class BaseBusySelectedState : BaseWrongSelectedState
    {
        public BaseBusySelectedState(IStateChanger stateChanger, IViewBaseSelector selector, IInformationText informationText)
            : base(stateChanger, selector, informationText, "Base is busy now. Choose another one")
        {
            AddTransition(new BaseBusySelectedToIdle(stateChanger, selector));
            AddTransition(new BaseBusySelectedToBaseSelected(stateChanger, selector));
            AddTransition(new BaseBusySelectedToBaseTooFewSelected(stateChanger, selector));
        }
    }
}