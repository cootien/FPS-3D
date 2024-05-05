using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FSMHelper;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private EnemyAttack enemyAttack;


    public Animator Animator => animator;
    public NavMeshAgent Agent => agent;
    public EnemyAttack EnemyAttack => enemyAttack;
    public Transform SpawnPos;

    private EnemyStateMachine m_EnemySM = null;

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

    //public void ComeBack()
    //{
    //    object[] args = new object[1];
    //    args[0] = "ComeBack";
    //    m_EnemySM.BroadcastMessage(args);
    //}

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

}
