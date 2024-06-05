using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightRayCast : MonoBehaviour
{
    [SerializeField] Transform point1;
    [SerializeField] Transform point2;

    public float lightRadius = 3f; 
    public LayerMask playerLayer; 


    private void Update()
    {
        float lightLength = Vector3.Distance(point1.position, point2.position);

        Collider[] colliders = Physics.OverlapCapsule(point1.position, point2.position, lightRadius, playerLayer);
        if(colliders.Length > 0)
        {
            Debug.Log("Detect player");
        }   
        
    }
}

