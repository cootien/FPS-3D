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
                Debug.Log("=======Blood");
            }
        }
    }
    //private IEnumerator DelayedAttack()
    //{
    //    yield return new WaitForSeconds(attackDelay);
    //    isAttacking = true;

    //    // Simulate the duration of the attack (adjust this duration as needed)
    //    yield return new WaitForSeconds(0.1f);

    //    isAttacking = false;
    //}

    //void AttackRaycast()
    //{
    //    if (Physics.Raycast(weapon.transform.position, weapon.transform.forward, out RaycastHit hit, attackDistance))
    //    {
    //        weapon.ShowHitEffect(hit);

    //        if (hit.collider.CompareTag("Enemy"))
    //        { weapon.DeliverDamage(hit.collider); }
    //    }
    //}


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
