using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private UnityEvent onAttack;
  
    public AudioSource WhoosingSound;
    public AudioSource StabbingSound;
    public int damage;

    private GameObject hitMarkerPrefab;
    private Health playerHealth;

    public void StartAttack()
    {
        animator.SetBool("Attack", true);
        WhoosingSound.Play();
    }

    public void StopAttack()
    {
        animator.SetBool("Attack", false);
    }

    private void ShowHitEffect(Collider collider)
    {
        if (collider == null) return;

        HitSurface hitSurface = collider.GetComponent<HitSurface>();
        var effectRotation = Quaternion.LookRotation(collider.transform.forward);

        if (hitSurface != null)
        {
           hitMarkerPrefab = HitEffectManager.Instance.effectMap[(int)hitSurface.surfaceType].effectPrefab;
        }
        Instantiate(hitMarkerPrefab, collider.transform.position,effectRotation);
    }
    
    public void DeliverDamage(Collider enemy)
    {

        Health health = enemy.GetComponentInParent<Health>();
        StabbingSound.Play();
        if (health != null)
        {
            Debug.Log("Deliver Damage");
            health.TakeDamage(damage);
        }
        ShowHitEffect(enemy);
    }
    

}
