using Bases;
using UnityEngine;

namespace Bots
{
    public class BaseMember : MonoBehaviour, IBaseMember
    {
        [SerializeField] private MembersStorage _storage;

        public IMembersStorage MembersStorage { get; private set; }
        public TaskAcceptor TaskAcceptor { get; private set; }

        public void SetBase(IMembersStorage storage)
        {
            MembersStorage?.CheckOut(this);
            MembersStorage = storage;
            MembersStorage.CheckIn(this);
        }

        public void CheckOut()
        {
            MembersStorage?.CheckOut(this);
            MembersStorage = null;
        }

        public void Init(TaskAcceptor taskAcceptor)
        {
            TaskAcceptor = taskAcceptor;

            if (_storage)
                SetBase(_storage);
        }
    }
}