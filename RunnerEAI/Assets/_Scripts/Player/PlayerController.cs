using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : PlayerData
    {
        HorizontalMover _horizontalMover;
        VerticalMover _verticalMover;
        PlayerInput _playerInput;
        Jump _jump;
        Rigidbody rb;

        public static bool fall;
        Vector3 Direction;

        float inputHorValue;
        void Start()
        {
            Direction = Vector3.forward;
            fall = false;
        }
        void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _verticalMover = new VerticalMover(this);
            _jump = new Jump(this);
            _playerInput = new PlayerInput();
            rb = GetComponent<Rigidbody>();
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
    }

}
