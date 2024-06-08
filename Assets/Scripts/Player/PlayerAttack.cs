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
        animator.SetBool("Detected", true);
    }

    public void StopAttack()
    {
        animator.SetBool("Detected", false);
    }

    public void DeliverDamage(Collider enemy)
    {
        Debug.Log("Deliver Damage");
        Health health = enemy.GetComponentInParent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
    

}
