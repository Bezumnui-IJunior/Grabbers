using System;
using Bases.Transitions;
using Spawners;
using StateMachines;

namespace Bases.States
{
    public class CreateNewBotState : State
    {
        private readonly BotFactory _botFactory;
        private readonly IMembersStorage _membersStorage;
        private readonly int _price;
        private readonly IWarehouse _warehouse;

        public CreateNewBotState(IStateChanger stateChanger, BotFactory botFactory, IWarehouse warehouse, int price, IMembersStorage membersStorage) : base(stateChanger)
        {
            _botFactory = botFactory;
            _warehouse = warehouse;
            _price = price;
            _membersStorage = membersStorage;
            AddTransition(new CreateNewBotToCollecting(stateChanger));
        }

        public override void Enter()
        {
            if (_warehouse.Amount < _price)
                throw new Exception("Invalid state. Warehouse.Amount is less that price required");

            _warehouse.RemoveItems(_price);
            _botFactory.CreateBot(_membersStorage);
        }
    }
}