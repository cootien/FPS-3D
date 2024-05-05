using System.Collections;
using System.Collections.Generic;
using FSMHelper; 
using UnityEngine;
using UnityEngine.AI; 

public class EnemyState_Idle : BaseFSMState
{
    private EnemyStateMachine _enemySM;

    private Transform _patrolCenter;
    public float patrolRadius = 10f;
    public float minDistanceToTarget = 2f;
    public float stoppingDistance = 1f;
    public float speed = 3f;

    private NavMeshAgent _agent;

    public override void Enter()
    {
        //Debug.Log("========= Enter state Idle");

        if (_enemySM == null)
        {
            _enemySM = (EnemyStateMachine)GetStateMachine();
        }

        _patrolCenter = _enemySM.EnemyAI.SpawnPos;
        _agent = _enemySM.EnemyAI.Agent;
        _agent.speed = speed;
        _agent.stoppingDistance = stoppingDistance;

        SetNewDestination();

        _enemySM.EnemyAI.Animator.SetBool("IsPatrolling", true);
    }
    public override void Update()
    {
        if (!_enemySM.EnemyAI.Agent.pathPending && _enemySM.EnemyAI.Agent.remainingDistance <= _enemySM.EnemyAI.Agent.stoppingDistance)
        {
            SetNewDestination();
        }
    }
    public override void Exit()
    {
    }

    void SetNewDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        Vector3 newDestination = _patrolCenter.position + randomDirection;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(newDestination, out hit, patrolRadius, NavMesh.AllAreas))
        {
            _enemySM.EnemyAI.Agent.SetDestination(hit.position);
        }
    }

    public override void ReceiveMessage(object[] args)
    {
        // Debug.Log("============ State Idle receved message : " + args.ToString());
        if (args.Length == 1 && (string)args[0] == "Detected")
        {
            DoTransition(typeof(EnemyState_Patrolling));
        }
    }
}
