using System.Collections;
using UnityEngine;
using Devic.Scripts.Utils.JumpRaycaster;
using Assets.Scripts.Core.Interfaces;

namespace Assets.Scripts.Player
{
    public class PlayerMovment : MonoBehaviour, IMoveable
    {
        private CharacterController _controller;
        
        private bool _isPlayerGrounded;
        private float _gravity = -9.8f;
        private float _fallForce = 3f;

        private float _playerMoveSpeed = 5f;
        
        private Vector3 _jumpVelocity;

        private Collider _playerCollider;

        

        // Use this for initialization
        void Start()
        {
            _controller = GetComponent<CharacterController>();
            _playerCollider = GetComponent<Collider>();
        }

        // Update is called once per frame
        void Update()
        {
            Move(true);
        }
        public void Move(bool isAlive)
        {
            if (isAlive)
            {
                _isPlayerGrounded = JumpRaycaster.CheckIfIsGrounded(_playerCollider);
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
            }
        }
        private void MovePlayerByAxis()
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _controller.Move(move * Time.deltaTime * _playerMoveSpeed);
            
            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }
        }
        private void WatchForPlayerJump()
        {
            if (Input.GetButtonDown("Jump") && _isPlayerGrounded)
            {
                _jumpVelocity.y -= Mathf.Sqrt(-200f * _fallForce * _gravity);
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