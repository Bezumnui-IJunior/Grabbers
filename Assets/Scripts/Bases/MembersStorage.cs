using System.Collections.Generic;
using Base;
using Bots;
using UnityEngine;

namespace Bases
{
    public class MembersStorage : MonoBehaviour, IReadyBotsProvider
    {
        [SerializeField] private List<Bots.Bot> _members;
        private readonly List<TaskAcceptor> _botsReady = new List<TaskAcceptor>();
        private IBase _base;

        public IEnumerable<TaskAcceptor> BotsReady => _botsReady;

        private void OnEnable()
        {
            foreach (Bots.Bot member in _members)
                InitMember(member);
        }

        private void OnDisable()
        {
            foreach (Bots.Bot member in _members)
                DeinitMember(member);
        }

        public void OccupyBot(TaskAcceptor taskAcceptor)
        {
            _botsReady.Remove(taskAcceptor);
        }

        private void InitMember(Bots.Bot member)
        {
            member.TaskAcceptor.GotReady += OnReady;
            member.ChangeBase(_base);

            if (member.TaskAcceptor.CanAcceptTask())
                _botsReady.Add(member.TaskAcceptor);
        }

        private void DeinitMember(Bots.Bot member)
        {
            member.TaskAcceptor.GotReady -= OnReady;
        }

        private void OnReady(TaskAcceptor taskAcceptor)
        {
            _botsReady.Add(taskAcceptor);
        }

        public void Init(IBase @base)
        {
            _base = @base;
        }
    }
}