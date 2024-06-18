using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public delegate void EnemyDeathAction(Vector3 position);
    public static event EnemyDeathAction OnEnemyDeath;

    // Method to call the event with position
    public void EnemyDied(Vector3 deathPosition)
    {
        if (OnEnemyDeath != null)
            OnEnemyDeath(deathPosition);
    }
}

