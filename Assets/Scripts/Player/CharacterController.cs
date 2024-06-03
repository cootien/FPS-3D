using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Test // adding namespace to separate between Character Controller of Unity vs self-created
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody rigibody;


        private bool IsWalkForward;
        private bool IsWalkBack;
        private bool IsAttack;

        private float _targetRotationY;

        public float WalkSpeedMax;

        private float currentSpeed;
        public float rotateSpeed;

 
        void Start()
        {
            CameraSwitcher.Instance.PrimaryCam();
           // animator = GetComponent<Animator>();ss
            Physics.gravity = new Vector3(0, -20f, 0);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                CameraSwitcher.Instance.PrimaryCam();
                IsWalkForward = true;

                if (currentSpeed < WalkSpeedMax)
                {
                    currentSpeed += 0.1f;
                }
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                IsWalkForward = false;
                currentSpeed = 0;
            }

            if (IsWalkForward)
            {
                animator.SetBool("IsWalkForward", true);
                var t = currentSpeed / WalkSpeedMax;
               // animator.SetFloat("Speed", t);
                WalkForward();
            }
            else
            {
                animator.SetBool("IsWalkForward", false);
                StopMove();
            }

            if (Input.GetKey(KeyCode.S))
            {
                IsWalkBack = true;
                currentSpeed = WalkSpeedMax;
                WalkBack();
                animator.SetBool("IsWalkBack", true);



            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("IsWalkBack", false);

                StopMove();
            }

            if (Input.GetMouseButtonDown(0))
            {
                IsAttack = true;
                currentSpeed = 0;
                animator.SetBool("Attack", true);
              
            }
            if (Input.GetMouseButtonUp(0))
            {
                IsAttack = false;
                animator.SetBool("Attack", false);
            }

            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(0, mouseX * rotateSpeed, 0));
            _targetRotationY = transform.eulerAngles.y;
        }

        private void WalkForward()
        {

            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotationY, 0.0f) * Vector3.forward;

           rigibody.velocity = new Vector3(targetDirection.normalized.x * currentSpeed, rigibody.velocity.y, targetDirection.normalized.z * currentSpeed);
           
        }

        private void WalkBack()
        {


            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotationY, 0.0f) * Vector3.back;
            rigibody.velocity = targetDirection.normalized * currentSpeed;
            rigibody.velocity = new Vector3(targetDirection.normalized.x * currentSpeed, rigibody.velocity.y, targetDirection.normalized.z * currentSpeed);
        }

        private void StopMove()
        {

            rigibody.velocity = new Vector3(0, rigibody.velocity.y, 0);
            rigibody.velocity = Vector3.zero;
        }

    }
}

