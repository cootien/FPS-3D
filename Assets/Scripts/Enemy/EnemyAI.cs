using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FSMHelper;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    //[SerializeField] private NavMeshAgent agent;
    [SerializeField] private EnemyAttack enemyAttack;
    //[SerializeField] private EnemyMovement enemyMovement;


    public Animator Animator => animator;
    //public NavMeshAgent Agent => agent;
    public EnemyAttack EnemyAttack => enemyAttack;
    //public EnemyMovement EnemyMovement => enemyMovement;
    public Transform SpawnPos;

    private EnemyStateMachine m_EnemySM = null;
    //private Coroutine attackCoroutine;
    private float attackDuration = 5f;

    private Transform _target;

    public Transform EnemyTargetMove
    {
        get => _target;
        set
        {
            _target = value;
        }
    }


    void Start()
    {
        m_EnemySM = new EnemyStateMachine(this);
        m_EnemySM.StartSM();
    }

    void Update()
    {
        m_EnemySM.UpdateSM();
    }

    void OnDestroy()
    {
        if (m_EnemySM != null)
        {
            m_EnemySM.StopSM();
            m_EnemySM = null;
        }
    }

    //public void TracePlayer()
    //{
    //    object[] args = new object[1];
    //    args[0] = "Trace";
    //    m_EnemySM.BroadcastMessage(args);
    //}

    public void Idle()
    {
        object[] args = new object[1];
        args[0] = "Idle";
        m_EnemySM.BroadcastMessage(args);
    }

    public void Attack()
    {
        object[] args = new object[1];
        args[0] = "Attack";
        m_EnemySM.BroadcastMessage(args);
    }

    public void Patrol()
    {
        object[] args = new object[1];
        args[0] = "Patrol";
        m_EnemySM.BroadcastMessage(args);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Attack");

            Attack();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("attack exit");
            //if (attackCoroutine != null)
            //    StopCoroutine(attackCoroutine);
             Patrol();
        }
    }
    IEnumerator Delay()
    {
        float elapsedTime = 0f;
        while (elapsedTime < attackDuration)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
        }

    }
    
}