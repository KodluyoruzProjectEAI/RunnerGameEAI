using System.Collections;
using System.Collections.Generic;
using Help;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerController : PlayerData
    {
        public static event System.Action OnJump;
        public static event System.Action OnRun;
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
            LevelManager.OnNextLevel += PlayerReset;
            GameManager.OnResetGame += PlayerReset;
            GameManager.OnDead += PlayerDead;
        }
        void OnDisable()
        {
            LevelManager.OnNextLevel -= PlayerReset;
            GameManager.OnResetGame -= PlayerReset;
            GameManager.OnDead -= PlayerDead;
        }
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            _playerController = GetComponent<PlayerController>();

            _horizontalMover = new HorizontalMover(this);
            _verticalMover = new VerticalMover(this);
            _jump = new Jump(this);
            _playerInput = gameObject.AddComponent<PlayerInput>();//mono ekledim playerinput a
          
        }
        void Start()
        {
            _playerController.SavePlayerValues(HorizontalSpeed, VerticalSpeed ,JumpPower);
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
                OnRun?.Invoke();
            }
        }
        void FixedUpdate()
        {
            if (IsJump)
            {
                _jump.Active(JumpPower);
                OnJump?.Invoke();
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
