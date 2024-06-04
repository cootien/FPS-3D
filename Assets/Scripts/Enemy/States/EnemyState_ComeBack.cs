using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMHelper;

public class EnemyState_ComeBack : BaseFSMState
{
    private EnemyStateMachine _enemySM;

    public override void Enter()
    {
        if(_enemySM == null)
        {
            _enemySM = (EnemyStateMachine)GetStateMachine();
        }
    }
    public override void Update()
    {
        _enemySM.EnemyAI.Agent.SetDestination(_enemySM.EnemyAI.SpawnPos.position);
        if(Vector3.Distance(_enemySM.EnemyAI.transform.position,_enemySM.EnemyAI.SpawnPos.position) <= 1f)
        {
            DoTransition(typeof(EnemyState_Patrolling));
        }
    }
    public override void ReceiveMessage(object[] args)
    {
        if(args.Length ==1 && (string)args[0] == "Patrol")
        {
            DoTransition(typeof(EnemyState_Patrolling));
        }
    }
}
