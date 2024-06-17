using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : Singleton<EnemyManager>
{
    public UnityEvent<Transform> onTeamMemberDie;


    public void OnEnemyDie(Transform enemyDiePos)
    {
        Debug.Log("===EnemyManager enter OnEnemyDie");

        onTeamMemberDie.Invoke(enemyDiePos);
    }
    
}
