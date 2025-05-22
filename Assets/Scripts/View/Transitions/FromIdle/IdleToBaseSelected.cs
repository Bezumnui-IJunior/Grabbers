using StateMachines;

namespace View.Transitions
{
    public class IdleToBaseSelected : BaseSelectedCorrectTransition
    {
        public IdleToBaseSelected(IStateChanger stateChanger, IViewBaseSelector selector) : base(stateChanger, selector) { }
    }
}