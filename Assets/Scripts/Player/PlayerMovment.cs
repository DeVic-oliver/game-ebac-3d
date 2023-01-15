using System.Collections;
using UnityEngine;
using Devic.Scripts.Utils.JumpRaycaster;

namespace Assets.Scripts.Player
{
    public class PlayerMovment : MonoBehaviour
    {
        private CharacterController _controller;
        
        private bool _isPlayerGrounded;
        private float _gravity = -9.8f;
        private float _fallForce = 3f;

        private float _playerMoveSpeed = 5f;
        
        private Vector3 movementVector;
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
            _isPlayerGrounded = JumpRaycaster.CheckIfIsGrounded(_playerCollider);
            if (_isPlayerGrounded && _jumpVelocity.y < 0)
            {
                _jumpVelocity.y = 0f;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _controller.Move(move * Time.deltaTime * _playerMoveSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            // Changes the height position of the player..
            if (Input.GetButtonDown("Jump") && _isPlayerGrounded)
            {
                _jumpVelocity.y -= Mathf.Sqrt(-200f * _fallForce * _gravity);
            }

            _jumpVelocity.y += _gravity * Time.deltaTime;
            _controller.Move(_jumpVelocity * Time.deltaTime);

        }

     

    }
}