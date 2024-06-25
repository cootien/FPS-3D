using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Audio;

namespace Test // adding namespace to separate between Character Controller of Unity vs self-created
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody rigibody;


        private bool IsWalkForward;
        private bool IsWalkBack;
        private bool IsWalkLeft;
        private bool IsWalkRight;


        private bool IsAttack;

        private float _targetRotationY;

        public AudioSource WalkingSound;
        public float WalkSpeedMax;
        public int damage;
        private Collider enemy;

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
            // IsWalkForward
            if (Input.GetKeyDown(KeyCode.W))
            {
                CameraSwitcher.Instance.PrimaryCam();
                IsWalkForward = true;
                IsWalkBack = false;


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

                WalkForward();
            }
            else
            {
                animator.SetBool("IsWalkForward", false);
                StopMove();
            }

            // IsWalkBack

            if (Input.GetKeyDown(KeyCode.S))
            {
                //WalkingSound.Play();
                IsWalkBack = true;
                IsWalkForward = false;
                WalkBack();

            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                IsWalkBack = false;
                currentSpeed = 0;

                StopMove();
            }
            if (IsWalkBack)
            {
                animator.SetBool("IsWalkBack", true);

                WalkForward();
            }
            else
            {
                animator.SetBool("IsWalkBack", false);
                StopMove();
            }

            // IsWalkLeft
            if (Input.GetKeyDown(KeyCode.A))
            {
                IsWalkLeft = true;
                IsWalkBack = false;
                IsWalkForward = false;
                IsWalkRight = false;

                currentSpeed = WalkSpeedMax;

            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                IsWalkLeft = false;

                StopMove();
            }
            if (IsWalkLeft)
            {
                animator.SetBool("IsWalkLeft", true);
                currentSpeed = 0;

                WalkForward();
            }
            else
            {
                animator.SetBool("IsWalkLeft", false);
                StopMove();
            }

            // IsWalkRight
            if (Input.GetKeyDown(KeyCode.D))
            {
                IsWalkLeft = false;
                IsWalkBack = false;
                IsWalkForward = false;
                IsWalkRight = true;

                currentSpeed = WalkSpeedMax;

            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                IsWalkRight = false;

                StopMove();
            }
            if (IsWalkRight)
            {
                animator.SetBool("IsWalkRight", true);
                currentSpeed = 0;

                WalkForward();
            }
            else
            {
                animator.SetBool("IsWalkRight", false);
                StopMove();
            }

            //IsAttack
            if (Input.GetKeyDown(KeyCode.X))
            {
                IsAttack = true;
                currentSpeed = 0;
                PlayerAttack.Instance.StartAttack();
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                IsAttack = false;
                PlayerAttack.Instance.StopAttack();

            }
           

            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(0, mouseX * rotateSpeed, 0));
            _targetRotationY = transform.eulerAngles.y;
        }

        private void WalkForward()
        {
            if (!WalkingSound.isPlaying)
            {
                WalkingSound.Play();
            }

            //Debug.Log($"==gbgbt");

            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotationY, 0.0f) * Vector3.forward;

            rigibody.velocity = new Vector3(targetDirection.normalized.x * currentSpeed, rigibody.velocity.y, targetDirection.normalized.z * currentSpeed);

        }

        private void WalkBack()
        {
            if (!WalkingSound.isPlaying)
            {
                WalkingSound.Play();
            }
            

            //Debug.Log($"===");

            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotationY, 0.0f) * Vector3.back;
            rigibody.velocity = targetDirection.normalized * currentSpeed;
            rigibody.velocity = new Vector3(targetDirection.normalized.x * currentSpeed, rigibody.velocity.y, targetDirection.normalized.z * currentSpeed);
        }

        private void StopMove()
        {
            //WalkingSound.Stop();
            rigibody.velocity = new Vector3(0, rigibody.velocity.y, 0);
            rigibody.velocity = Vector3.zero;
        }

    }
}


