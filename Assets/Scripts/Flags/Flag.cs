using System;
using Misc;
using UnityEngine;

namespace Flags
{
    public class Flag : MonoBehaviour, ISpawnable<Flag>, IFlag
    {
        public event Action<Flag> Dying;

        public Vector3 Position => transform.position;

        public void Remove()
        {
            Dying?.Invoke(this);
        }

        public void Destroy()
        {
            gameObject.SetActive(false);
        }

        void ISpawnable<Flag>.TurnOn()
        {
            this.TurnOn();
        }

        void ISpawnable<Flag>.TurnOff()
        {
            this.TurnOff();
        }

        public void Init(Vector3 position)
        {
            transform.position = position;
        }
    }
}