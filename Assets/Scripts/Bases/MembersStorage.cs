using System;
using System.Collections.Generic;
using System.Linq;
using Bots;
using UnityEngine;

namespace Bases
{
    public class MembersStorage : MonoBehaviour, IMembersStorage
    {
        private readonly HashSet<TaskAcceptor> _botsReady = new HashSet<TaskAcceptor>();
        private readonly List<IBaseMember> _members = new List<IBaseMember>();

        public int Count => _members.Count;
        public Vector3 SpawnPoint => transform.position;
        public IEnumerable<TaskAcceptor> BotsReady => _botsReady;

        public IDropOffArea DropOffArea { get; private set; }

        private void OnEnable()
        {
            foreach (IBaseMember member in _members)
                InitMember(member);
        }

        private void OnDisable()
        {
            foreach (IBaseMember member in _members)
                DeinitMember(member);
        }

        public void CheckOut(IBaseMember member)
        {
            if (_members.Contains(member) == false)
                throw new ArgumentException("Member not in the list");

            DeinitMember(member);
            _members.Remove(member);
            Debug.Log($"{member} removed");
        }

        public void CheckIn(IBaseMember member)
        {
            if (_members.Contains(member))
                throw new ArgumentException("Member already in the list");

            _members.Add(member);
            InitMember(member);
        }

        public void OccupyBot(TaskAcceptor taskAcceptor)
        {
            _botsReady.Remove(taskAcceptor);
        }

        private void InitMember(IBaseMember member)
        {
            member.TaskAcceptor.GotReady += OnReady;

            if (member.TaskAcceptor.CanAcceptTask())
                _botsReady.Add(member.TaskAcceptor);
        }

        private void DeinitMember(IBaseMember member)
        {
            member.TaskAcceptor.GotReady -= OnReady;
            _botsReady.Remove(member.TaskAcceptor);
        }

        private void OnReady(TaskAcceptor taskAcceptor)
        {
            if (IsMember(taskAcceptor))
                _botsReady.Add(taskAcceptor);
        }

        private bool IsMember(TaskAcceptor taskAcceptor)
        {
            return _members.Any(member => member.TaskAcceptor.GetInstanceID() == taskAcceptor.GetInstanceID());
        }

        [ContextMenu("Log Members")]
        private void LogMembers()
        {
            Debug.Log("Members: ");

            foreach (IBaseMember baseMember in _members)
                Debug.Log(baseMember);

            Debug.Log("Ready: ");

            foreach (TaskAcceptor acceptor in _botsReady)
                Debug.Log(acceptor);
        }

        public void Init(IDropOffArea dropOffArea)
        {
            DropOffArea = dropOffArea;
        }
    }
}