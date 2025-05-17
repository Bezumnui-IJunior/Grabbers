using UnityEngine;

namespace Bot.States
{
    public abstract class FollowItemState : State
    {
        [SerializeField] private PointFollower _pointFollower;

        private IBotTasker _tasker;

        private void OnEnable()
        {
            _pointFollower.Reached += ChangeState<ICollectingState>;

            if (_pointFollower.TrySetPath(_tasker.Task.Position) == false)
                ChangeState<IIdleState>();
        }

        private void OnDisable()
        {
            _pointFollower.Reached -= ChangeState<ICollectingState>;
        }

        public void Init(IBotTasker tasker)
        {
            _tasker = tasker;
        }
    }
}