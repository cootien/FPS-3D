using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : Singleton<PlayerAttack>
{
    [SerializeField] private Animator animator;
    [SerializeField] private UnityEvent onAttack;
    [SerializeField] private Weapon weapon;

    public float attackDistance = 5f;
    private float attackDelay = 8f;

    public int damage;

    public AudioSource WhoosingSound;


    private bool isAttacking;
    public bool IsAttacking => isAttacking;


    public void StartAttack()
    {
        animator.SetBool("Attack", true);
        WhoosingSound.Play();
        isAttacking = true;

        PerformWeaponCheck();
        //StartCoroutine(DelayedAttack());

    }

    public void StopAttack()
    {
        animator.SetBool("Attack", false);
        isAttacking = false;
      
    }
    private void PerformWeaponCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackDistance);
        foreach (Collider collider in colliders)
        {
            weapon.ShowHitEffect(collider);
            if (collider.CompareTag("Enemy"))
            {
                weapon.DeliverDamage(collider);
            }
        }
    }
    

}
