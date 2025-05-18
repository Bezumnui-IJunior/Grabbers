using Bots.Transitions;
using StateMachines;

namespace Bots.States
{
    public class DropOffState : State
    {
        private readonly DropOffer _dropOffer;

        public DropOffState(IStateChanger stateChanger, DropOffer dropOffer, Inventory inventory) : base(stateChanger)
        {
            _dropOffer = dropOffer;
            _dropOffer.Init(inventory);
            AddTransition(new ImmediateTransition<IdleState>(stateChanger));
        }

        public override void Enter()
        {
            _dropOffer.Unload();
        }
    }
}