using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] PatrolPoints patrolPoints;
    [SerializeField] float waypointDwellTime;
    [SerializeField] private Animator anim;
    [SerializeField] private EnemySO enemySO;

    [SerializeField] private LightRayCast rayCast;

    private bool IsPatrol;
    private bool Detected;

    public Health playerHealth;
    public int damage;

    int currentPointIndex;

    public float currentSpeed;
    public float targetSpeed;
    


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerHealth.TakeDamage(damage);
    }
        
    private void Update()
    {
        if (!Detected)
        {
            patrolBehavior();
        }
  
    }

    private void onAttack(int index)
    {
        if(playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void patrolBehavior()
    {
        float distanceToWaypoint = Vector3.Distance(transform.position, patrolPoints.GetPointPosition(currentPointIndex));

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
    public void chasingBehavior()
    {
        if (!Detected)
        {
            Detected = true;
            anim.SetBool("Detected", true);

            Debug.Log("AnimDetected play");


            currentSpeed = targetSpeed;
            navMeshAgent.speed = currentSpeed;
            Debug.Log("Speed up");
            StartCoroutine(AttackDuration());
        }
        
    }

    private IEnumerator AttackDuration()
    {
        float duration = 5f;
        while (duration > 0)
        {
            duration -= Time.deltaTime;
            navMeshAgent.SetDestination(Player.Instance.PlayerFoot.transform.position);

            transform.LookAt(Player.Instance.PlayerFoot.transform.position);
            yield return null;
        }

        Detected = false;
        anim.SetBool("Detected", false);
        currentSpeed = targetSpeed;
        navMeshAgent.speed = currentSpeed;
        
    }
    

}
