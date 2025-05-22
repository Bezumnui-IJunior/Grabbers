using Bots.Transitions;
using Misc;
using StateMachines;

namespace Bots.States
{
    public class WaitCollectingState : State
    {
        private readonly CooldownTimer _timer;

        public WaitCollectingState(IStateChanger stateChanger, CooldownTimer timer) : base(stateChanger)
        {
            _timer = timer;
            AddTransition(new WaitCollectingToCollecting(stateChanger, timer));
        }

        public override void Enter()
        {
            _timer.Start();
        }
    }
}