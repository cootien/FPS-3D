using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;

    public AudioSource StabbingSound;
    private GameObject hitMarkerPrefab;

    private void Start()
    {
        Debug.Log("=== weapon start");

    }
    private void Update()
    {
        Debug.Log("=== weapon update");
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("==== weapon");
    //    ShowHitEffect(collision.collider);

    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        Debug.Log("=======Blood");
    //        DeliverDamage(collision.collider);
    //    }
    //}
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("==== weapon");
        ShowHitEffect(collider);

        if (collider.CompareTag("Enemy"))
        {
            Debug.Log("=======Blood");
            DeliverDamage(collider);
        }
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
    }

    private void ShowHitEffect(Collider collider)
    {
        if (collider == null) return;
        HitSurface hitSurface = collider.GetComponent<HitSurface>();
        var effectRotation = Quaternion.LookRotation(collider.transform.forward);

        hitMarkerPrefab = HitEffectManager.Instance.effectMap[(int)hitSurface.surfaceType].effectPrefab;
       
        Instantiate(hitMarkerPrefab, collider.transform.position, effectRotation);
    }

}
