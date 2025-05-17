using System;
using UnityEngine;

namespace Bot.States
{
    public class ReturnState : State, IReturnState
    {
        [SerializeField] private Vector3 _basePosition;
        [SerializeField] private PointFollower _pointFollower;

        private void OnEnable()
        {
            if (_pointFollower.TrySetPath(_basePosition) == false)
                throw new Exception("Unexpected bot position. Could not reach the base");

            _pointFollower.Reached += ChangeState<IDropOffState>;
        }

        private void OnDisable()
        {
            _pointFollower.Reached -= ChangeState<IDropOffState>;
        }
    }
}