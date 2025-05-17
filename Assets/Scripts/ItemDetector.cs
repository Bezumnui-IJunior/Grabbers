using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ItemDetector : MonoBehaviour
{
    private readonly List<ICollectable> _collectables = new List<ICollectable>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ICollectable collectable))
            _collectables.Add(collectable);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ICollectable collectable))
            _collectables.Remove(collectable);
    }

    public bool TryGiveItem(int itemId, out ICollectable collectable)
    {
        collectable = _collectables.FirstOrDefault(item => item.UniqueID == itemId);

        return collectable != null;
    }
}