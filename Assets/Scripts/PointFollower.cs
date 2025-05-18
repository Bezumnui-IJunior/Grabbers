using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PointFollower : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    private NavMeshPath _path;

    public event Action Reached;

    public bool TrySetPath(Vector3 position)
    {
        _path = new NavMeshPath();
        _agent.CalculatePath(position, _path);

        if (_path.status != NavMeshPathStatus.PathComplete)
            return false;

        _agent.SetPath(_path);
        StartCoroutine(Reaching());

        return true;
    }

    private IEnumerator Reaching()
    {
        while (_agent.hasPath)
            yield return null;

        Reached?.Invoke();
    }
}