using System;
using Bot;
using Misc;
using UnityEngine;

namespace Items
{
    public abstract class Item : MonoBehaviour, ICollectable
    {
        public event Action<Item> Dying;
        protected abstract string Name { get; }
        public int UniqueID => GetInstanceID();

        public abstract bool IsAlive { get; }

        public Vector3 Position => transform.position;

        public abstract void Collect(IInventory inventory);

        public CollectedItem GetCollectedItem() =>
            new CollectedItem(Name);

        protected void Die() =>
            Dying?.Invoke(this);
    }

    public abstract class Item<T> : Item, ISpawnable<T> where T : Item<T>
    {
        private ISpawnable<T> _spawnableImplementation;
        public new event Action<T> Dying;
        public override bool IsAlive => gameObject.activeSelf;

        public void Destroy() =>
            Destroy(gameObject);

        void ISpawnable<T>.TurnOn()
        {
            this.TurnOn();
        }

        void ISpawnable<T>.TurnOff()
        {
            this.TurnOff();
        }

        public override void Collect(IInventory inventory)
        {
            inventory.Collect(this);

            if (Dying == null)
                throw new Exception("Couldn't die: the item is already dead");

            Dying.Invoke((T)this);
            Die();
        }
    }
}