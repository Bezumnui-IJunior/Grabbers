using Bases.States;
using StateMachines;

namespace Bases.Transitions
{
    public class CollectingToEarningForBase : Transition<EarningForBaseState>
    {
        private readonly BaseCreator _baseCreator;

        public CollectingToEarningForBase(IStateChanger stateChanger, BaseCreator baseCreator) : base(stateChanger)
        {
            _baseCreator = baseCreator;
        }

        protected override bool CanTransit() =>
            _baseCreator.HasScheduledTask;
    }
}