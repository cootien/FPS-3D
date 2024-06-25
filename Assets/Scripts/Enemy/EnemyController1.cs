using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


public class EnemyController1 : Singleton<EnemyController>
{

    //private NavMeshAgent navMeshAgent;
    //[SerializeField] PatrolPoints patrolPoints;
    //[SerializeField] float waypointDwellTime;
    //[SerializeField] private Animator anim;
    //[SerializeField] private EnemySO enemySO;

    //[SerializeField] private LightRayCast rayCast;

    //private bool Detected;
    //public bool IsDead;


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

    //    }
    //    else
    //    {
    //        currentPointIndex = patrolPoints.getNextPointIndex(currentPointIndex);

    //    }
    //}
    //public void OnPlayerDetected()
    //{
    //    Detected = true;
    //    anim.SetBool("Detected", true);

    //    navMeshAgent.speed = 2f;

    //    StartCoroutine(attackTimeDelay());

    //    patrolBehavior();

    //}

    //public void OnPlayerUndected()
    //{

    //    Detected = false;
    //    anim.SetBool("Detected", false);

    //    navMeshAgent.speed = 1f;

    //}
    //public void OnDie()
    //{
    //    Detected = false;
    //    IsDead = true;

    //    navMeshAgent.enabled = false;

    //    Rigidbody rb = GetComponent<Rigidbody>();
    //    if (rb != null)
    //    {
    //        rb.velocity = Vector3.zero;
    //        rb.angularVelocity = Vector3.zero;
    //        rb.constraints = RigidbodyConstraints.FreezeAll;
    //    }
        
    //    MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
    //    foreach (MonoBehaviour script in scripts)
    //    {
    //        if (script != this) // Avoid disabling the OnDie script itself if it's a MonoBehaviour
    //        {
    //            script.enabled = false;
    //        }
    //    }
    //    enabled = false;
    //}

    //public void Gather(Vector3 enemyDiePos)
    //{
    //    Debug.Log($"===" );
    //    if (IsDead) return;

    //    transform.LookAt(enemyDiePos);
    //    navMeshAgent.SetDestination(enemyDiePos);

    //    if (Vector3.Distance(enemyDiePos, transform.position) < 1f)
    //    {
    //        StartCoroutine(attackTimeDelay());
    //        Debug.Log($"==={gameObject.name} Reached team member's death position");

    //        patrolBehavior();
    //    }
    //}

    //private IEnumerator attackTimeDelay()
    //{
    //    yield return new WaitForSeconds(2f); // Wait for 3 seconds

    //    //Debug.Log($"===End of attackTimeDelay");

    //}
    //void OnEnable()
    //{
    //    EnemyManager.OnEnemyDeath += GatherAndChase;
    //}

    //void OnDisable()
    //{
    //    EnemyManager.OnEnemyDeath -= GatherAndChase;
    //}

    //void GatherAndChase(Vector3 deathPosition)
    //{
    //    // Use deathPosition to move towards that point
    //    Debug.Log($"=== GatherAndChase");

    //}

}
