using System.Collections;
using System.Collections.Generic;
using Help;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerController : PlayerData
    {
        PlayerController _playerController;
        HorizontalMover _horizontalMover;
        VerticalMover _verticalMover;
        PlayerInput _playerInput;
        Jump _jump;
        Rigidbody rb;

        public static bool fall;
        Vector3 Direction;

        float inputHorValue;

        void OnEnable()
        {
            GameManager.OnResetGame += PlayerReset;
            GameManager.OnDead += PlayerDead;
        }
        void OnDisable()
        {
            GameManager.OnResetGame -= PlayerReset;
            GameManager.OnDead -= PlayerDead;
        }
        void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _verticalMover = new VerticalMover(this);
            _jump = new Jump(this);
            _playerInput = new PlayerInput();
            rb = GetComponent<Rigidbody>();
        }
        void Start()
        {
            _playerController.SavePlayerValues(HorizontalSpeed, VerticalSpeed, JumpPower);
            Direction = Vector3.forward;
            fall = false;
        }
     
        void Update()
        {  
            inputHorValue = _playerInput.GetMoveInput();
            if (rb.velocity.y != 0)
            {
                IsHorizontal = false;
            }
            else 
            {
                IsHorizontal = true;
            }
        }
        void FixedUpdate()
        {
            if (IsJump)
            {
                _jump.Active(JumpPower);
                IsJump = false;
            }
            if (IsHorizontal)
            {
                _horizontalMover.Active(inputHorValue, HorizontalSpeed, BoundX);
            }
            _verticalMover.Active(VerticalSpeed);
        }
        void PlayerDead()
        {
            VerticalSpeed = 0;
            JumpPower = 0;
            HorizontalSpeed = 0;
        }
        void PlayerReset()
        {
            _playerController.ResetPlayerValues();
        }

    }

}
