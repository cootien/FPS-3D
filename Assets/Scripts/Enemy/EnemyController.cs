using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : Singleton<EnemyController>
{
    //private NavMeshAgent navMeshAgent;
    //[SerializeField] PatrolPoints patrolPoints;
    //[SerializeField] float waypointDwellTime;
    //[SerializeField] private Animator anim;
    //[SerializeField] private EnemySO enemySO;
    ////[SerializeField] private Player PlayerFoot;

    //[SerializeField] private LightRayCast rayCast;

    //private bool IsPatrol;
    //private bool Detected;
    //private bool IsAttacked;
    //private bool IsDead;
    //private float idleTimer;


    ////public float attackTime = 5f;


    ////public Health playerHealth;
    //public int damage;

    //int currentPointIndex;


    //private void Awake()
    //{
    //    navMeshAgent = GetComponent<NavMeshAgent>();
    //}

    //private void Update()
    //{

    //    patrolBehavior();

    //}


    //public void patrolBehavior()
    //{
    //    if (IsDead) return;

    //    float distanceToWaypoint = Vector3.Distance(transform.position, patrolPoints.GetPointPosition(currentPointIndex));

    //    transform.LookAt(patrolPoints.GetPointPosition(currentPointIndex));

    //    if (distanceToWaypoint > 1f)
    //    {
    //        navMeshAgent.SetDestination(patrolPoints.GetPointPosition(currentPointIndex));
    //        //Debug.Log($"===distanceToWaypoint - SetDestination : {currentPointIndex}");

    //    }
    //    else
    //    {
    //        currentPointIndex = patrolPoints.getNextPointIndex(currentPointIndex);
    //        //Debug.Log($"===patrolBehavior - getNextPointIndex: {currentPointIndex}");

    //    }
    //}
    ////public void idleBehavior()
    ////{

    ////}
    ////public void beAttacked()
    ////{

    ////}

    //public void OnPlayerDetected()
    //{
    //    Detected = true;
    //    anim.SetBool("Detected", true);

    //    Debug.Log("===Enemy enter OnPlayerDetected");
    //    navMeshAgent.speed = 2f;

    //    StartCoroutine(attackTimeDelay());

    //    patrolBehavior();
    //    //Debug.Log($"===Enemy speed : {navMeshAgent.speed}");

    //}

    //public void OnPlayerUndected()
    //{
    //    //Debug.Log("===Enemy enter OnPlayerUndected");

    //    Detected = false;
    //    anim.SetBool("Detected", false);

    //    navMeshAgent.speed = 1f;
    //    //Debug.Log($"===Enemy speed : {navMeshAgent.speed}");

    //}

    //public void OnDie()
    //{
    //    //Debug.Log("===Enemy Die");
    //    Detected = false;
    //    IsDead = true;
    //    //OnTeamEnemyDie(gameObject.transform.position);

    //    navMeshAgent.enabled = false;

    //    Rigidbody rb = GetComponent<Rigidbody>();
    //    if (rb != null)
    //    {
    //        rb.velocity = Vector3.zero;
    //        rb.angularVelocity = Vector3.zero;
    //        rb.constraints = RigidbodyConstraints.FreezeAll;
    //    }
    //    OnTeamEnemyDie(gameObject.transform.position);

    //    enabled = false;
    //}

    //public void OnTeamEnemyDie(Vector3 enemyDiePos)
    //{
    //    //Debug.Log($"===OnTeamEnemyDie {enemyDiePos.position.x},{enemyDiePos.position.z}");
    //    if(Vector3.Distance(enemyDiePos,gameObject.transform.position) > 100f)
    //    {
    //        //float distanceToWaypoint = Vector3.Distance(transform.position, enemyDiePos);

    //        transform.LookAt(enemyDiePos);
    //        navMeshAgent.SetDestination(enemyDiePos);

    //        Debug.Log($"===Team member in < 30f");


    //        if (Vector3.Distance(enemyDiePos, gameObject.transform.position) < 1f)
    //        {
    //            StartCoroutine(attackTimeDelay());
    //            Debug.Log($"===Reached team member die posT");
    //            patrolBehavior();
    //        }
    //    }
    //}
    //public void OnTeamEnemyDie(Vector3 enemyDiePos)
    //{
    //    // Log the function call for debugging purposes
    //    Debug.Log($"===OnTeamEnemyDie called with position: {enemyDiePos}");

    //    // Check the distance between the current position and the enemy's death position
    //    //if (Vector3.Distance(enemyDiePos, transform.position) > 100f)
    //    //{
    //        // Look towards the enemy's death position
    //        transform.LookAt(enemyDiePos);

    //        // Set the destination of the NavMeshAgent to the enemy's death position
    //        navMeshAgent.SetDestination(enemyDiePos);

    //        Debug.Log($"===Team member is within < 100f, moving towards: {enemyDiePos}");

    //        // Check if the enemy has reached the destination
    //        if (Vector3.Distance(enemyDiePos, transform.position) < 1f)
    //        {
    //            // Start the attack time delay coroutine
    //            StartCoroutine(AttackTimeDelay());
    //            Debug.Log($"===Reached team member's death position");

    //            // After reaching the destination, continue patrolling
    //            patrolBehavior();
    //        }
    //    //}
    //    //else
    //    //{
    //    //    Debug.Log($"===Team member is not within < 100f, staying in patrol mode");
    //    //}
    //}

    // Example coroutine for attack delay
    //    private IEnumerator AttackTimeDelay()
    //    {
    //        // Wait for the specified delay
    //        yield return new WaitForSeconds(1.0f); // Adjust the delay as needed



    //    }

    //        private IEnumerator attackTimeDelay()
    //    {
    //        yield return new WaitForSeconds(2f); // Wait for 3 seconds

    //        //Debug.Log($"===End of attackTimeDelay");

    //    }


}
