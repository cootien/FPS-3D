using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FSMHelper;


public class EnemyState_Idle : BaseFSMState
{
    private EnemyStateMachine _enemySM;

    private float waitTime;
    private NavMeshAgent _agent;

    public override void Enter()
    {
        Debug.Log("===== enter state Idle");
        if (_enemySM == null)
        {
            _enemySM = (EnemyStateMachine)GetStateMachine();
        }
        _agent = _enemySM.EnemyAI.Agent;
        _agent.isStopped = true; 

        _enemySM.EnemyAI.Animator.SetBool("IsPatrolling", false);
        waitTime = Random.Range(5, 7);
    }
    public override void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            _agent.isStopped = false;
            DoTransition(typeof(EnemyState_Patrolling));
        }
    }
    public override void Exit()
    {
      
    }

    public override void ReceiveMessage(object[] args)
    {
        if (args.Length == 1 && (string)args[0] == "Detected")
        {
            DoTransition(typeof(EnemyState_Attack));
        }
    }
}
