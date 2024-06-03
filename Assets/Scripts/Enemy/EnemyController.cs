using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] PatrolPoints patrolPoints;
    [SerializeField] float waypointDwellTime;

    int currentPointIndex; 

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
        
    private void Update()
    {
        patrolBehavior();

        Debug.Log(currentPointIndex);
    }
    private void patrolBehavior()
    {
        float distanceToWaypoint = Vector3.Distance(transform.position, patrolPoints.GetPointPosition(currentPointIndex));
        Debug.Log(distanceToWaypoint);

        transform.LookAt(patrolPoints.GetPointPosition(currentPointIndex));

        if (distanceToWaypoint > 1f)
        {
            navMeshAgent.SetDestination(patrolPoints.GetPointPosition(currentPointIndex));
        }
        else
        {
            currentPointIndex = patrolPoints.getNextPointIndex(currentPointIndex);
        }
    }

}
