using Bases.States;
using StateMachines;

namespace Bases.Transitions
{
    public class EarningForBaseToCollecting : Transition<CollectingState>
    {
        private readonly int _price;
        private readonly IWarehouse _warehouse;

        public EarningForBaseToCollecting(IStateChanger stateChanger, int price, IWarehouse warehouse) : base(stateChanger)
        {
            _price = price;
            _warehouse = warehouse;
        }

        protected override bool CanTransit() =>
            _warehouse.Amount >= _price;
    }
}