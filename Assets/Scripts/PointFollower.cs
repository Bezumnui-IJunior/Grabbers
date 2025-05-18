using UnityEngine;
using UnityEngine.AI;

public class PointFollower : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    private NavMeshPath _path;

    public bool IsBusy => _agent.hasPath;

    public bool TrySetPath(Vector3 position)
    {
        _path = new NavMeshPath();
        _agent.CalculatePath(position, _path);

        if (_path.status != NavMeshPathStatus.PathComplete)
            return false;

        _agent.SetPath(_path);

        return true;
    }

    public void Stop()
    {
        _agent.ResetPath();
    }
}