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

    [SerializeField] private LightRayCast rayCast;

    private bool IsRunning;
    public bool IsDead;
    private bool IsIdle;
    private bool IsBeingHurt;



    public int damage;

    int currentPointIndex;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        followPoints();

    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (IsBeingHurt) return;
        if (IsRunning) return;

        if (other.gameObject.CompareTag("Weapon"))
        {
            //Debug.Log("OnTriggerEnter weapon");

            OnHurt();
        }
    }
    public void followPoints()
    {
        //Debug.Log($"patrol called: {IsIdle}, {IsRunning}");

        if (IsDead) return;
        if (IsIdle) return;
        

        float distanceToWaypoint = Vector3.Distance(transform.position, patrolPoints.GetPointPosition(currentPointIndex));

        transform.LookAt(patrolPoints.GetPointPosition(currentPointIndex));

        if (distanceToWaypoint > 1f)
        {
    
            navMeshAgent.SetDestination(patrolPoints.GetPointPosition(currentPointIndex));

        }
        else
        {
            OnIdle();

            currentPointIndex = patrolPoints.getNextPointIndex(currentPointIndex);
            //Debug.Log($"scurrent position set");
        }
    }
    //IDLE 
    public void OnIdle()
    {
        if (IsRunning) return;

        IsIdle = true;
        IsBeingHurt = false;
        

        anim.SetBool("Idle", true);
        anim.SetBool("Hurt", false);
        anim.SetBool("Run", false);

        navMeshAgent.speed = 0f;

    }
    public void OnIdleFinished()
    {

        IsIdle = false;

        anim.SetBool("Idle", false);
        navMeshAgent.speed = 1f;
        //Debug.Log("Ennter on finnishIdle 3");

    }

    //Hurt
    public void OnHurt()
    {
        IsBeingHurt = true;
        IsIdle = false;
        IsRunning = false;

        anim.SetBool("Hurt", true);
        anim.SetBool("Idle", false);
        anim.SetBool("Run", false);

    }
    public void OnHurtFinished()
    {
        IsBeingHurt = false;
        anim.SetBool("Hurt", false);
        navMeshAgent.speed = 1f;
        //Debug.Log("Ennter on finnish Hurt");

        OnPlayerDetected();
    }

    //PlayerDetected
    public void OnPlayerDetected()
    {
        IsRunning = true;
        IsIdle = false;
        IsBeingHurt = false;
        //Debug.Log("Ennter on OnPlayerDetected");
        //Debug.Log ($"OnPlayerDetected Running {IsRunning}");


        anim.SetBool("Run", true);
        anim.SetBool("Hurt", false);
        anim.SetBool("Idle", false);

        //followPoints();
        navMeshAgent.speed = 2f;

        StartCoroutine(runningTime());
        //Debug.Log("===finished waiting some seconds");
        //Debug.Log($"nav mesh speed - run {navMeshAgent.speed}");


        //OnPlayerUndected();
    }

    public void OnPlayerUndected()
    {
        IsRunning = false;
        IsBeingHurt = false;
        IsIdle = false;

        //Debug.Log($"OnPlayerUndected Running {IsRunning}");

        anim.SetBool("Run", IsRunning);
        anim.SetBool("Hurt", IsBeingHurt);
        anim.SetBool("Idle", IsIdle);

        navMeshAgent.speed = 1f;

    }
    public void OnDie()
    {
        IsRunning = false;
        IsDead = true;

        navMeshAgent.enabled = false;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            if (script != this) // Avoid disabling the OnDie script itself if it's a MonoBehaviour
            {
                script.enabled = false;
            }
        }
        enabled = false;
    }

    private IEnumerator runningTime()
    {
        //Debug.Log($"will wait some seconnnds");

        yield return new WaitForSeconds(10f); // Wait for 3 seconds

        //Debug.Log($"calling OnPlayerUndected");
        OnPlayerUndected();


    }


}
