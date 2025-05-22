using Bots.States;
using Misc;
using StateMachines;

namespace Bots
{
    public class StateMachineInitializer
    {
        public void InitializeStateMachine(StateMachine stateMachine, TaskAcceptor taskAcceptor, BotTasker tasker, PointFollower pointFollower, ItemDetector itemDetector, Inventory inventory,
            ICoroutineExecutor executor, float pickupSeconds, BaseMember member, DropOffer dropOffer, BaseBuilder baseBuilder)
        {
            stateMachine.AddState(typeof(IdleState), new IdleState(stateMachine, taskAcceptor, tasker));
            stateMachine.AddState(typeof(GoToTaskState), new GoToTaskState(stateMachine, pointFollower, tasker, member));
            stateMachine.AddState(typeof(WaitCollectingState), new WaitCollectingState(stateMachine, new CooldownTimer(executor, pickupSeconds)));
            stateMachine.AddState(typeof(CollectingState), new CollectingState(stateMachine, tasker, itemDetector, inventory));
            stateMachine.AddState(typeof(ReturnState), new ReturnState(stateMachine, member, dropOffer, pointFollower));
            stateMachine.AddState(typeof(DropOffState), new DropOffState(stateMachine, dropOffer, inventory));
            stateMachine.AddState(typeof(BuildingBaseState), new BuildingBaseState(stateMachine, baseBuilder, tasker, member));
        }
    }
}