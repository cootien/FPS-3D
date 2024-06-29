using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


public class LightRayCast : MonoBehaviour
{
    [SerializeField] Transform point1;
    [SerializeField] Transform point2;

    public UnityEvent playerDetected;
    public UnityEvent playerUndetected;

    public float lightRadius = 3f;
    public int damage;

    public LayerMask playerLayer;


    public void OnTriggerEnter(Collider other)
    {

        float lightLength = Vector3.Distance(point1.position, point2.position);

        Collider[] colliders = Physics.OverlapCapsule(point1.position, point2.position, lightRadius*lightLength, playerLayer);
        if (colliders.Length > 0)
        {
            playerDetected.Invoke();
            DeliverDamage(other);
            //Debug.Log($"deliver dame on player");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        float lightLength = Vector3.Distance(point1.position, point2.position);

        Collider[] colliders = Physics.OverlapCapsule(point1.position, point2.position, lightRadius * lightLength, playerLayer);
        if (colliders.Length == 0)
        {
            playerUndetected.Invoke();
            
        }
    }
    public void DeliverDamage(Collider player)
    {
        Health health = player.GetComponentInParent<Health>();
        
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }

}

