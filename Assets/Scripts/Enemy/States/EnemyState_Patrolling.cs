using System.Collections;
using System.Collections.Generic;
using FSMHelper; 
using UnityEngine;
using UnityEngine.AI; 

public class EnemyState_Patrolling : BaseFSMState
{
    private EnemyStateMachine _enemySM;
    private NavMeshAgent _agent;
    public float speed;

    private PatrolPoints patrolPoints;
    int currentPointIndex;


    public override void Enter()
    {
        Debug.Log("========= Enter state Patrol");

        if (_enemySM == null)
        {
            _enemySM = (EnemyStateMachine)GetStateMachine();
        }
        speed = Random.Range(3f, 5f);
        _agent.speed = speed;

        patrolDestination(_enemySM.EnemyAI.transform);

        _enemySM.EnemyAI.Animator.SetBool("IsPatrolling", true);
    }
    
    public override void Exit()
    {
    }

    private void patrolDestination(Transform enemyTransform)
    {
        float distanceToWaypoint = Vector3.Distance(_enemySM.EnemyAI.transform.position, patrolPoints.GetPointPosition(currentPointIndex));

        _enemySM.EnemyAI.transform.LookAt(patrolPoints.GetPointPosition(currentPointIndex));

        if (distanceToWaypoint > 1f)
        {
            _agent.SetDestination(patrolPoints.GetPointPosition(currentPointIndex));
        }
        else
        {
            currentPointIndex = patrolPoints.getNextPointIndex(currentPointIndex);
        }
    }

    public override void ReceiveMessage(object[] args)
    {
         if (args.Length == 1 && (string)args[0] == "Attack")
        {
            DoTransition(typeof(EnemyState_Attack));
        }
    }
}
