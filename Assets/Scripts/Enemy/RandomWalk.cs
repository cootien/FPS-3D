using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomWalk : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("SetRandomDestination", 0f, 5f); 
    }
    private void Update()
    {
        // check if the gaent has reached its destination
        if(!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            SetRandomDestination();
        }
    }
    void SetRandomDestination()
    {
        //generate random point onn the Navmesh within a certain range from the current position
        Vector3 randomDirection = Random.insideUnitSphere * 10f;
        randomDirection += transform.position;


        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas);

        //set the agent's destination to the random point
        agent.SetDestination(hit.position);
    }
    public void Stop ()
    {
        
    }
}
