using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance { get; set; }
    private Weapon weaponToPickup;

    //singletTon
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Update()
    {

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Weapon"))
    //    {
    //        var outline = other.gameObject.GetComponent<Outline>();

    //        if (outline != null)
    //        {
    //            outline.enabled = true;
    //        }
    //    }
        
    //}
}
