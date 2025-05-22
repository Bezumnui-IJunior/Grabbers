using Bots.States;
using Misc;
using StateMachines;
using StateMachines.Transitions;

namespace Bots.Transitions
{
    public class WaitCollectingToCollecting : DelayedTransition<CollectingState>
    {
        public WaitCollectingToCollecting(IStateChanger stateChanger, CooldownTimer timer) : base(stateChanger, timer) { }
    }
}