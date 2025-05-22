using StateMachines;

namespace View.Transitions
{
    public class BaseWrongSelectedToBaseSelected : BaseSelectedCorrectTransition
    {
        public BaseWrongSelectedToBaseSelected(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}