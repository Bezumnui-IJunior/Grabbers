using Bases.States;
using StateMachines;

namespace Bases.Transitions
{
    public class CollectingToCreateNewBot : Transition<CreateNewBotState>
    {
        private readonly int _price;
        private readonly IWarehouse _warehouse;

        public CollectingToCreateNewBot(IStateChanger stateChanger, IWarehouse warehouse, int price) : base(stateChanger)
        {
            _warehouse = warehouse;
            _price = price;
        }

        protected override bool CanTransit() =>
            _warehouse.Amount >= _price;
    }
}