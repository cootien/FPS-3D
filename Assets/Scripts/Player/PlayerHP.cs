using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : Health
{
    //[SerializeField] private EnemySO PlayerSO;
    //public int MaxHP;


    protected override void Start()
    {
        base.Start();
        //MaxHP = 20;
        //Debug.Log($"Max HP - enemyHealth: {MaxHP}");
    }

    public override void Die()
    {
        GameManager.Instance.OnGameover();
    }
}
