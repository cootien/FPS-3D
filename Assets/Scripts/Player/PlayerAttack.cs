using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : Singleton<PlayerAttack>
{
    [SerializeField] private Animator animator;
    [SerializeField] private UnityEvent onAttack;

    public int damage;

    public AudioSource WhoosingSound;
    public AudioSource StabbingSound;

    public void StartAttack()
    {
        animator.SetBool("Attack", true);
        WhoosingSound.Play();
    }

    public void StopAttack()
    {
        animator.SetBool("Attack", false);
    }

    //public void DeliverDamage(Collider enemy)
    //{
    //    Health health = enemy.GetComponentInParent<Health>();
    //    StabbingSound.Play();
    //    if (health != null)
    //    {
    //        Debug.Log("Deliver Damage");
    //        health.TakeDamage(damage);
    //    }
    //}

}
