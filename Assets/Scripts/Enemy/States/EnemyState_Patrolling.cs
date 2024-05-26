using System.Collections;
using System.Collections.Generic;
using FSMHelper; 
using UnityEngine;
using UnityEngine.AI; 

public class EnemyState_Patrolling : BaseFSMState
{
    private EnemyStateMachine _enemySM;

    private Transform _patrolCenter;
    public float patrolRadius = 50f;
    public float minDistanceToTarget = 2f;
    public float stoppingDistance = 1f;
    public float speed = 3f;

    private NavMeshAgent _agent;

    public override void Enter()
    {
        Debug.Log("========= Enter state Patrol");

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
        if (args.Length == 1 && (string)args[0] == "Idle")
        {
            DoTransition(typeof(EnemyState_Idle));
        }
        else if (args.Length == 1 && (string)args[0] == "Attack")
        {
            DoTransition(typeof(EnemyState_Attack));
        }
    }
}
