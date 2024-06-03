using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem; 
using Cinemachine;

public class MovementController: MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;
    [SerializeField] private Rigidbody rigibody;
    Animator animator;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;
    bool isAttackPressed;

    float rotationFactorPerFrame = 5.0f;
    float currentSpeed = 3.0f;
    float _targetRotationY;


    private void Awake()
    {
        playerInput = new PlayerInput(); 
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Physics.gravity = new Vector3(0, 0, 0);

        playerInput.CharacterControls.Move.started += onMovementInput;
        playerInput.CharacterControls.Move.canceled += onMovementInput;
        playerInput.CharacterControls.Move.performed += onMovementInput;
        playerInput.CharacterControls.Attack.started += onAttack;
        playerInput.CharacterControls.Attack.canceled += onAttack;

    }
    void handleGravity()
    {
        if (characterController.isGrounded)
        {
            float groundedGravity = -.05f;
            currentMovement.y = groundedGravity;
        }
        else
        {
            float gravity = -9.8f;
            currentMovement.y += gravity;
        }
    }
    void onAttack(InputAction.CallbackContext context)
    {
        isAttackPressed = context.ReadValueAsButton();
    }
    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    
    }
    void handleRotation()
    {
        Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotationY, 0.0f) * Vector3.forward;
        rigibody.velocity = new Vector3(targetDirection.normalized.x * currentSpeed, rigibody.velocity.y, targetDirection.normalized.z * currentSpeed);

    }
    void handleAnimation()
    {
        bool _isWalkForward = animator.GetBool("IsWalkForward");
        bool _isAttack = animator.GetBool("Attack");

        if((isMovementPressed && !_isWalkForward) &&  !isAttackPressed)
        {
            animator.SetBool("IsWalkForward", true); 
        }
        else if(!isMovementPressed && _isWalkForward)
        {
            animator.SetBool("IsWalkForward", false);
        }
        if((isAttackPressed && !_isAttack) && isMovementPressed)
        {
            animator.SetBool("Attack", true);
        }
        else if(!isAttackPressed && _isAttack)
        {
            animator.SetBool("Attack", false);
        }
    }
    private void Update()
    {
        handleGravity();
        handleAnimation();
        handleRotation();

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, mouseX * rotationFactorPerFrame, 0));
        _targetRotationY = transform.eulerAngles.y;

        if (isAttackPressed)
        {
            characterController.Move(currentMovement * 0f);
        }
        else if ( isMovementPressed)
        {
            characterController.Move(currentMovement * Time.deltaTime*currentSpeed);
        }
    }
    private void OnEnable()
    {
        playerInput.CharacterControls.Enable();
    }
    private void OnDisable()
    {
        playerInput.CharacterControls.Disable();
    }
}
