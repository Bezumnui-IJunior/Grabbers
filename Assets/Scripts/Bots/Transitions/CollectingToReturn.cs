using Bots.States;
using StateMachines;
using StateMachines.Transitions;

namespace Bots.Transitions
{
    public class CollectingToReturn : ImmediateTransition<ReturnState>
    {
        public CollectingToReturn(IStateChanger stateChanger) : base(stateChanger) { }
    }
}