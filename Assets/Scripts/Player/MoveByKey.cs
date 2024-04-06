using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveByKey : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    public float movingSpeed;
    public float jumpPower = 1f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
            
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 direction = transform.right * hInput + transform.forward * vInput;

        // 2 CharacterController : Unity & self-created
        // => class created CharacterController => add into namespace 
        characterController.SimpleMove(direction * movingSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            transform.DOMoveY(transform.position.y + jumpPower, 0.5f);
        }
    }

}
