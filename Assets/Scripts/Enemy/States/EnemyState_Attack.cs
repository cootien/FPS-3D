using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FSMHelper;

public class EnemyState_Attack : BaseFSMState
{
    private EnemyStateMachine _enemySM;
    public NavMeshAgent _agent;

    private float attackSpeed =6f;


    public override void Enter()
    {
        Debug.Log("============ Enemy Ataack");

        if (_enemySM == null)
        {
            _enemySM = (EnemyStateMachine)GetStateMachine();
            Debug.Log($"======= Enemy SM != null: {_enemySM != null}");
        }




        _agent.speed = attackSpeed;






        _enemySM.EnemyAI.EnemyAttack.StartAttack();





    }
    public override void Update()
    {
        _enemySM.EnemyAI.Agent.SetDestination(Player.Instance.PlayerFoot.transform.position);

        if (Vector3.Distance(_enemySM.EnemyAI.transform.position, Player.Instance.PlayerFoot.transform.position) > 80f)
        {
            Debug.Log("Player out of attack zone");
            DoTransition(typeof(EnemyState_ComeBack));
        }
    }
    public override void Exit()
    {
         _enemySM.EnemyAI.EnemyAttack.StopAttack();
    }
    public override void ReceiveMessage(object[] args)
    {
        if (args.Length == 1 && (string)args[0] == "ComeBack")
        {
            DoTransition(typeof(EnemyState_ComeBack));
        }
    }
}
