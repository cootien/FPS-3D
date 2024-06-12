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

    public float lightRadius = 3f; 
    public LayerMask playerLayer;



    public void OnTriggerEnter(Collider other)
    {

        float lightLength = Vector3.Distance(point1.position, point2.position);

        Collider[] colliders = Physics.OverlapCapsule(point1.position, point2.position, lightRadius*lightLength, playerLayer);
        if (colliders.Length > 0)
        {
            playerDetected.Invoke();
            //Debug.Log("Ontrigger enter player && PlayerDetected Invoked");
        }
    }

}

