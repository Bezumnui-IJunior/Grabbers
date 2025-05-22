using Bots.States;
using StateMachines;
using StateMachines.Transitions;

namespace Bots.Transitions
{
    public class BuildingBaseToIdle : ImmediateTransition<IdleState>
    {
        public BuildingBaseToIdle(IStateChanger stateChanger) : base(stateChanger) { }
    }
}