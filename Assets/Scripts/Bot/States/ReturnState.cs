using System;
using UnityEngine;

namespace Bot.States
{
    public class ReturnState : State, IReturnState
    {
        [SerializeField] private BaseMember _baseMember;
        [SerializeField] private DropOffer _dropOffer;
        [SerializeField] private PointFollower _pointFollower;

        private void OnEnable()
        {
            if (_pointFollower.TrySetPath(_baseMember.Base.Center) == false)
                throw new Exception("Unexpected bot position. Could not reach the base");

            _dropOffer.BaseEntered += ChangeState<IDropOffState>;
        }

        private void OnDisable()
        {
            _dropOffer.BaseEntered -= ChangeState<IDropOffState>;
        }
    }
}