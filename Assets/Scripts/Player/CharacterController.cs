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
        [SerializeField] private CinemachineVirtualCamera attackCamera;

        private bool IsMoveForward;
        private bool IsMoveBack;
        private bool IsAttack;

        private float _targetRotationY;

        public float WalkSpeedMax;

        private float currentSpeed;
        public float rotateSpeed;

 
        void Start()
        {
            animator = GetComponent<Animator>();
            Physics.gravity = new Vector3(0, -20f, 0);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                IsMoveForward = true;
                IsAttack = false;

                if (currentSpeed < WalkSpeedMax)
                {
                    currentSpeed += 0.1f;
                }
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                IsMoveForward = false;
                currentSpeed = 0;
            }

            if (IsMoveForward)
            {
                animator.SetBool("IsWalkForward", true);

                animator.SetBool("Attack", false);
                var t = currentSpeed / WalkSpeedMax;
                animator.SetFloat("Speed", t);
                WalkForward();
            }
            else
            {
                animator.SetBool("IsWalkForward", false);
                StopMove();
            }

            if (Input.GetKey(KeyCode.S))
            {
                IsMoveForward = false;
                IsMoveBack = true;
                IsAttack = false;
                currentSpeed = WalkSpeedMax;
                WalkBack();
                animator.SetBool("IsWalkForward", false);
                animator.SetBool("IsWalkBack", true);
                animator.SetBool("Attack", false);

            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("IsWalkBack", false);
                StopMove();
            }

            if (Input.GetKeyUp(KeyCode.X))
            {
                IsAttack = true;
                currentSpeed = 0;
            }

            if (IsAttack)
            {
                Attack();
                CameraSwitcher.Instance.TargetCam();
            }
            if (!IsAttack)
            {
                CameraSwitcher.Instance.PrimaryCam();
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
        private void Attack()
        {
            animator.SetBool("Attack", true);
        }

    }
}


