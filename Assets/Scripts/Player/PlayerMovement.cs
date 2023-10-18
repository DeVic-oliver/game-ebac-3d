using System.Collections;
using UnityEngine;
using Devic.Scripts.Utils.JumpRaycaster;
using Assets.Scripts.Core.Interfaces;

namespace Assets.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour, IMoveable
    {
        public bool IsMoving { get; private set; }
        public bool HasJumped { get; private set; }

        [SerializeField] private CharacterController _controller;
        
        private bool _isPlayerGrounded;
        private float _gravity = -9.8f;
        private float _fallForce = 3f;
        [SerializeField] private float _playerMoveSpeed = 10f;
        private float _defaultMoveSpeed;
        [SerializeField] private float _jumpThrust = 8f;
        private Vector3 _jumpVelocity;

        [SerializeField] private Collider _playerCollider;
        [SerializeField] private Animator _playerAnimator;

        
        public void AddValueToMoveSpeed(float value)
        {
            _playerMoveSpeed += value;
        }

        public void ResetMoveSpeed()
        {
            _playerMoveSpeed = _defaultMoveSpeed;
        }

        void Start()
        {
            _defaultMoveSpeed = _playerMoveSpeed;
            _controller = GetComponent<CharacterController>();
            _playerCollider = GetComponent<Collider>();
        }

        void Update()
        {
            Move(true);
        }

        public void Move(bool isAlive)
        {
            if (isAlive)
            {
                _isPlayerGrounded = JumpRaycaster.CheckIfIsGrounded(_playerCollider);
                _playerAnimator.SetBool("isOnGround", _isPlayerGrounded);
                MoveByCharacterController();
            }
        }

        private void MoveByCharacterController() 
        {
            SetPlayerYVelocityToZero();
            MovePlayerByAxis();
            WatchForPlayerJump();
        }

        private void SetPlayerYVelocityToZero()
        {
            if (_isPlayerGrounded && _jumpVelocity.y < 0)
            {
                _jumpVelocity.y = 0f;
                HasJumped = false;
                _playerAnimator.SetTrigger("Land");
            }
        }

        private void MovePlayerByAxis()
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _controller.Move(move * Time.deltaTime * _playerMoveSpeed);
            

            if (move != Vector3.zero)
            {
                IsMoving = true;
                gameObject.transform.forward = move;
                _playerAnimator.SetBool("Run", true);
            }
            else
            {
                IsMoving = false;
                _playerAnimator.SetBool("Run", false);
            }
        }

        private void WatchForPlayerJump()
        {
            if (Input.GetButtonDown("Jump") && _isPlayerGrounded)
            {   
                HasJumped = true;
                _jumpVelocity.y += Mathf.Sqrt(-_jumpThrust * _fallForce * _gravity);
                _playerAnimator.SetTrigger("Jump");
            }

            ReturnPlayerToGround();
        }

        private void ReturnPlayerToGround()
        {
            _jumpVelocity.y += _gravity * Time.deltaTime;
            _controller.Move(_jumpVelocity * Time.deltaTime);
        }
    }
}