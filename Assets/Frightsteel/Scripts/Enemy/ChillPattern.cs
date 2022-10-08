using UnityEngine;
using UnityEngine.AI;

public class ChillPattern : MonoBehaviour
{
    [SerializeField] private WayPoints _points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        GoToNextPoint();
    }


    void GoToNextPoint()
    {
        if (_points.GetWayPointCount() == 0)
            return;

        agent.destination = _points.GetWayPoint(destPoint).position;

        destPoint = (destPoint + 1) % _points.GetWayPointCount();
    }


    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GoToNextPoint();
    }
}