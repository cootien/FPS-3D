using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public int damage;
    private Health playerHealth;

    public void StartAttack()
    {
        animator.SetBool("Attack", true);
    }

    public void StopAttack()
    {
        animator.SetBool("Attack", false);
    }

    public void DeliverDamage(Collider enemy)
    {
        Health health = enemy.GetComponentInParent<Health>();
        if (health != null)
        {
            Debug.Log("Deliver Damage");
            health.TakeDamage(damage);
        }
    }
    

}
