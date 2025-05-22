using Bots.States;
using StateMachines;

namespace Bots.Transitions
{
    public class ReturnToDropOff : Transition<DropOffState>
    {
        private readonly IBaseConsistencyProvider _consistencyProvider;

        public ReturnToDropOff(IStateChanger stateChanger, IBaseConsistencyProvider consistencyProvider) : base(
            stateChanger)
        {
            _consistencyProvider = consistencyProvider;
        }

        protected override bool CanTransit() =>
            _consistencyProvider.IsInsideBase;
    }
}