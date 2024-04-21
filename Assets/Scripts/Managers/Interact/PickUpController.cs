using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpController : MonoBehaviour
{
    public static Interactable instance;

    public void Interact()
    {
        var outline = gameObject.GetComponent<Outline>();

        if (outline != null)
        {
            outline.enabled = true;
        }
    }
    // public static PickUpController Instance { get; set; }

    public Rigidbody rb;
    public SphereCollider coll;
    public Transform weaponContainer,player;

    public Weapon weaponToPickup = null;
    private Transform rootWeapon;

    private float pickUpRange = 2f;
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
        if (!equipped && weaponToPickup !=null && Input.GetKeyDown(KeyCode.E) && !slotFull)
            PickUp(weaponToPickup);

        if (equipped && Input.GetKeyDown(KeyCode.Q))
            Drop();
    }
    private void PickUp(Weapon weapon)
    {
        
            equipped = true;
            slotFull = true;
        
        //weaponToPickup.SetParent(weaponContainer);
       // weaponToPickup.localPosition = new Vector3(-2.558f,0.03f,-5.684f);
       // weaponToPickup.localRotation = new Quaternion(27, -0.8f, -3.5f, 0);
       // weaponToPickup.localScale = new Vector3(0.01f,0.01f,0.01f);

        //gameObject.transform.position = weaponContainer.transform.position;
            //gameObject.transform.rotation = weaponContainer.transform.rotation;

           // rb.isKinematic = true;
           // coll.isTrigger = true;

//            gameObject.GetComponent<MeshCollider>().enabled = false;            
    }
    private void Drop()
    {
        weaponContainer.DetachChildren();
        equipped = false;
        slotFull = false;

        rb.isKinematic = false;
        rb.AddForce(new Vector3(0, 5, 10), ForceMode.Impulse);
        ////coll.isTrigger = false;


        gameObject.transform.eulerAngles = Vector3.zero; // reset to no rotation


    }

}
