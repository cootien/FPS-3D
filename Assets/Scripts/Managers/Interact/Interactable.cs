using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : Singleton<Interactable>
{
    public Transform InteractorSource;
    public float InteractRange;

   

    private void Start()
    {
        
    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if(Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if(hitInfo.collider.gameObject.TryGetComponent( out Interactable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }

    private void Interact()
    {

    }
}
