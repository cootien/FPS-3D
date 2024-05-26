using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events; 

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemySO EnemySO;
    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;

    private Health playerHealth;

    public float reachingRadius;
    public UnityEvent onDestinationReached;
    public UnityEvent onStartMoving;

    private Transform _target;


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
    public void UpdateMovement()
    {
        if (_target != null)
        {
            var distance = Vector3.Distance(transform.position, _target.position);

            if (distance > reachingRadius)
            {
                agent.SetDestination(_target.position);
            }
            //else
            //{         
            //    StartAttack();
            //}
   
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, _target.eulerAngles.y + 180f, transform.eulerAngles.z);
        }
    }

    public void StartAttack()
    {

        anim.SetBool("Detected", true);
        anim.SetBool("IsPatrolling", false);
    }

    public void StopAttack()
    {
        anim.SetBool("Detected", false);
        anim.SetBool("IsPatrolling", true);
    }
    
    public void OnEnemyDie()
    {
        enabled = false;
        agent.isStopped = true;
        anim.SetTrigger("Die");
        Debug.Log("Die");
    }
    
}
