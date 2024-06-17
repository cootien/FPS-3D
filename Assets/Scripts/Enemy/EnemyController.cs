using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : Singleton<EnemyController>
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] PatrolPoints patrolPoints;
    [SerializeField] float waypointDwellTime;
    [SerializeField] private Animator anim;
    [SerializeField] private EnemySO enemySO;
    [SerializeField] private Player PlayerFoot;

    [SerializeField] private LightRayCast rayCast;

    private bool IsPatrol;
    private bool Detected;
    private bool IsAttacked;
    private bool IsDead;


    //public float attackTime = 5f;


    public Health playerHealth;
    public int damage;

    int currentPointIndex;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
    
        patrolBehavior();
      
    }
    

    public void patrolBehavior()
    {
        if (IsDead) return;

        float distanceToWaypoint = Vector3.Distance(transform.position, patrolPoints.GetPointPosition(currentPointIndex));

        transform.LookAt(patrolPoints.GetPointPosition(currentPointIndex));

        if (distanceToWaypoint > 1f)
        {
            navMeshAgent.SetDestination(patrolPoints.GetPointPosition(currentPointIndex));
            //Debug.Log($"===distanceToWaypoint - SetDestination : {currentPointIndex}");

        }
        else
        {
            currentPointIndex = patrolPoints.getNextPointIndex(currentPointIndex);
            //Debug.Log($"===patrolBehavior - getNextPointIndex: {currentPointIndex}");

        }
    }


    public void OnPlayerDetected()
    {
        Detected = true;
        anim.SetBool("Detected", true);

        Debug.Log("===Enemy enter OnPlayerDetected");
        navMeshAgent.speed = 2f;
        StartCoroutine(attackTimeDelay());

        Debug.Log($"===Enemy speed : {navMeshAgent.speed}");

    }

    public void OnPlayerUndected()
    {
        //Debug.Log("===Enemy enter OnPlayerUndected");

        Detected = false;
        anim.SetBool("Detected", false);

        navMeshAgent.speed = 1f;
        //Debug.Log($"===Enemy speed : {navMeshAgent.speed}");

    }
 
    public void OnDie()
    {
        Debug.Log("===Enemy Die");
        Detected = false;
        IsDead = true;
        EnemyManager.Instance.OnEnemyDie(gameObject.transform);

        navMeshAgent.enabled = false;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        enabled = false;
    }

    public void OnTeamEnemyDie(Transform enemyDiePos)
    {
        //Debug.Log($"===OnTeamEnemyDie {enemyDiePos.position.x},{enemyDiePos.position.z}");
        if(Vector3.Distance(enemyDiePos.position,gameObject.transform.position) > 10f)
        {
            Debug.Log("===Enemy receive message TeamMember die");

        }
    }



    private IEnumerator attackTimeDelay()
    {
        yield return new WaitForSeconds(2f); // Wait for 3 seconds
        patrolBehavior();

        //Debug.Log($"===End of attackTimeDelay");

    }


}
