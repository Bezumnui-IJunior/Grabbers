using StateMachines;
using View.Transitions;

namespace View.States
{
    public class BaseTooFewSelectedState : BaseWrongSelectedState
    {
        public BaseTooFewSelectedState(IStateChanger stateChanger, IViewBaseSelector selector, IInformationText informationText)
            : base(stateChanger, selector, informationText, "Too few bot. Should be more than 1")
        {
            AddTransition(new BaseTooFewSelectedToIdle(stateChanger, selector));
            AddTransition(new BaseTooFewSelectedToBaseBusySelected(stateChanger, selector));
            AddTransition(new BaseWrongSelectedToBaseSelected(stateChanger, selector));
        }
    }
}