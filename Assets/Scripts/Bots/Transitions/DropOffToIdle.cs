using Bots.States;
using StateMachines;
using StateMachines.Transitions;

namespace Bots.Transitions
{
    public class DropOffToIdle : ImmediateTransition<IdleState>
    {
        public DropOffToIdle(IStateChanger stateChanger) : base(stateChanger) { }
    }
}