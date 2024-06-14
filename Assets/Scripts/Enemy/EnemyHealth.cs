using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private EnemySO EnemySO;

    protected override void Start()
    {
        base.Start();
        MaxHP = EnemySO.HP;
        //Debug.Log($"Max HP - enemyHealth: {MaxHP}");
    }

    protected override void Die()
    {
        base.Die();
        MissionManager.Instance.OnEnemyKilled();

    }
}
