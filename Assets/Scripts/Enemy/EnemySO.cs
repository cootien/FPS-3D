using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "ScriptableObjects/CreateEnemySO")]
public class EnemySO : ScriptableObject
{
    public int HP;
    public int Damage;
    public float Speed;

}
