using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] private Transform playerFoot;
    [SerializeField] private Health healthPlayer;

    public Transform PlayerFoot => playerFoot;
    public Health HealthPlayer => healthPlayer;
}
