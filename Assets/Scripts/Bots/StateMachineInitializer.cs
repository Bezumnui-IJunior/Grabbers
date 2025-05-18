using Bot;
using Bots.States;
using Misc;
using StateMachines;

namespace Bots
{
    public class StateMachineInitializer
    {
        public void InitializeStateMachine(StateMachine stateMachine, TaskAcceptor taskAcceptor, BotTasker tasker, PointFollower pointFollower, ItemDetector itemDetector, Inventory inventory,
            ICoroutineExecutor executor, float pickupSeconds, BaseMember member, DropOffer dropOffer)
        {
            stateMachine.AddState(typeof(IdleState), new IdleState(stateMachine, taskAcceptor, tasker));
            stateMachine.AddState(typeof(FollowItemState), new FollowItemState(stateMachine, pointFollower, tasker));
            stateMachine.AddState(typeof(CollectingState), new CollectingState(stateMachine, itemDetector, inventory, tasker, new CooldownTimer(executor, pickupSeconds)));
            stateMachine.AddState(typeof(ReturnState), new ReturnState(stateMachine, member, dropOffer, pointFollower));
            stateMachine.AddState(typeof(DropOffState), new DropOffState(stateMachine, dropOffer, inventory));
        }
    }
}