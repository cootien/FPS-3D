using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [SerializeField] GameObject knife;
    
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform weaponContainer,player;

    private float pickUpRange = 4f;
    private float dropForwardForce=15f, dropUpwardForce=7f;

    public bool equipped;
    private static bool slotFull;

    private void Start()
    {
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;

        }
    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
            PickUp();

        if (equipped && Input.GetKeyDown(KeyCode.Q))
            Drop();
    }
    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        knife.transform.position = weaponContainer.transform.position;
        knife.transform.rotation = weaponContainer.transform.rotation;

        rb.isKinematic = true;
        coll.isTrigger = true;

        knife.GetComponent<MeshCollider>().enabled = false;

        knife.transform.SetParent(weaponContainer);
        
    }
    private void Drop()
    {
        weaponContainer.DetachChildren();
        equipped = false;
        slotFull = false;

        rb.isKinematic = false;
        coll.isTrigger = false;

        knife.transform.eulerAngles = new Vector3(knife.transform.position.x, knife.transform.position.z, knife.transform.position.y);
        knife.GetComponent<MeshCollider>().enabled = true;

    }

}
