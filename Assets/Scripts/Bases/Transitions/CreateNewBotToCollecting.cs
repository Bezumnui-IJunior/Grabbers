using Bases.States;
using StateMachines;
using StateMachines.Transitions;

namespace Bases.Transitions
{
    public class CreateNewBotToCollecting : ImmediateTransition<CollectingState>
    {
        public CreateNewBotToCollecting(IStateChanger stateChanger) : base(stateChanger) { }
    }
}