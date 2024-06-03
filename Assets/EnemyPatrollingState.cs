using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSMHelper; 

public class EnemyPatrollingState : BaseFSMState
{
    private EnemyStateMachine _enemySM;
    private Transform _target;
    public override void Enter()
    {
        if (_enemySM == null)
        {
            _enemySM = (EnemyStateMachine)GetStateMachine();
        }
        Debug.Log("========= Enter state Trace");
    }
    public override void Update()
    {
        //  Vector3 nextPosition = _enemySM.EnemyAI.patrolPoints.get
       

        if (Vector3.Distance(_enemySM.EnemyAI.transform.position, _enemySM.EnemyAI.SpawnPos.position) > 30f)
        {
            DoTransition(typeof(EnemyState_Idle));
        }
        else if (Vector3.Distance(_enemySM.EnemyAI.transform.position, Player.Instance.PlayerFoot.transform.position) <= 2f)
        {
            DoTransition(typeof(EnemyState_Attack));
        }
    }
    public override void Exit()
    {
    }
    public override void ReceiveMessage(object[] args)
    {
        if (args.Length == 1 && (string)args[0] == "Attack")
        {
            DoTransition(typeof(EnemyState_Attack));
        }
        else if (args.Length == 1 && (string)args[0] == "Idle")
        {
            DoTransition(typeof(EnemyState_Idle));
        }
    }
}
