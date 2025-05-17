using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NavmeshPointGenerator
{
    private static readonly float Sqrt3 = Mathf.Sqrt(3);
    private readonly float _radius;
    private readonly NavMeshSurface _surface;

    public NavmeshPointGenerator(NavMeshSurface surface)
    {
        _surface = surface;
        _radius = surface.size.x * Sqrt3;
    }

    [ContextMenu(nameof(TryGetPointOnSurface))]
    public bool TryGetPointOnSurface(out Vector3 position)
    {
        Vector3 pos = GetPositionInRadius();

        if (NavMesh.SamplePosition(pos, out NavMeshHit hit, 100, NavMesh.AllAreas) == false)
        {
            position = default;

            return false;
        }

        position = hit.position;

        return true;
    }

    private Vector3 GetPositionInRadius() =>
        _surface.center + Random.insideUnitSphere * _radius;
}