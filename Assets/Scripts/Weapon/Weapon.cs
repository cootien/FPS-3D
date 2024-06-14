using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;

    public AudioSource StabbingSound;
    private GameObject hitMarkerPrefab;


    //private void OnTriggerEnter(Collider collider)
    //{
    //    if (PlayerAttack.Instance.IsAttacking)
    //    {
    //        Debug.Log("===Player attacking & enter collider");
    //        ShowHitEffect(collider);

    //        if (collider.CompareTag("Enemy"))
    //        {s
    //            Debug.Log("=======Blood");
    //            DeliverDamage(collider);
    //        }
    //    }
    //}

    public void DeliverDamage(Collider enemy)
    {
        Health health = enemy.GetComponentInParent<Health>();
        StabbingSound.Play();
        if (health != null)
        {
            //Debug.Log("Deliver Damage");
            health.TakeDamage(damage);
        }
    }
    public void ShowHitEffect(Collider collider)
    {
        if (collider == null) return;
        HitSurface hitSurface = collider.GetComponent<HitSurface>();
        if (hitSurface == null) return;  // Added check to prevent null reference
        var effectRotation = Quaternion.LookRotation(collider.transform.forward);

        hitMarkerPrefab = HitEffectManager.Instance.effectMap[(int)hitSurface.surfaceType].effectPrefab;

        Instantiate(hitMarkerPrefab, collider.transform.position, effectRotation);
    }

    //public void ShowHitEffect(RaycastHit hit)
    //{
    //    Debug.Log("===weapon show hit effect enter");
    //    if (hit.collider == null) return;
    //    HitSurface hitSurface = hit.collider.GetComponent<HitSurface>();
    //    if (hitSurface == null) return;


    //    var effectRotation = Quaternion.LookRotation(hit.normal);

    //    hitMarkerPrefab = HitEffectManager.Instance.effectMap[(int)hitSurface.surfaceType].effectPrefab;

    //    Instantiate(hitMarkerPrefab, hit.point, effectRotation);
    //}

}
