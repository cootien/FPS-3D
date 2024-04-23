using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   

    public void Interact()
    {
        var outline = gameObject.GetComponent<Outline>();

        if (outline != null)
        {
            outline.enabled = true;
        }
    }
 
}
