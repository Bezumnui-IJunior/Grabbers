using System;
using Bot;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract string Name { get; }
    public Vector3 Position => transform.position;

    public CollectedItem GetCollectedItem() =>
        new CollectedItem(Name);
}

public abstract class Item<T> : Item, ICollectable, ISpawnable<T> where T : Item<T>
{
    public event Action<T> Dying;

    public void Collect(IInventory inventory)
    {
        inventory.Collect(this);
        Dying?.Invoke((T)this);
    }

    public void Destroy() =>
        Destroy(gameObject);

    public void Enable() =>
        gameObject.SetActive(true);

    public void Disable() =>
        gameObject.SetActive(false);
}