using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events; 

public class EnemyAttack : MonoBehaviour
{
    //[SerializeField] private EnemySO EnemySO;
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _target;
    //private Health playerHealth;

    public float reachingRadius;
    public float attackTime = 5f; 
    public UnityEvent onDestinationReached;
    public UnityEvent onStartMoving;


    public Transform EnemyTargetMove
    {
        get => _target;
        set
        {
            _target = value;
        }
    }

    private void Start()
    {
        //playerHealth = Player.Instance.HealthPlayer;
    }

    public void StartAttack()
    {
        //RandomMovement();
        anim.SetBool("Detected", true);

    }

    public void StopAttack()
    {
        //RandomMovement();
        anim.SetBool("Detected", false);
    }

    public void OnAttack()
    {
        
    }
    
    public void OnEnemyDie()
    {
        enabled = false;
        _agent.isStopped = true;
        anim.SetTrigger("Die");
        Debug.Log("Die");
    }
    //private void RandomMovement()
    //{
    //    attackTime -= Time.deltaTime;
    //    if(attackTime <= 1) => anim.SetInteger("DetectedIndex", 1);
    //}
    
}
