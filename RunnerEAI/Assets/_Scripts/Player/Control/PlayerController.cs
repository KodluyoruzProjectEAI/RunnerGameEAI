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

        float inputHorValue;
        void OnEnable()
        {
            LevelManager.OnNextLevel += PlayerReset;
            MenuManager.OnResetGame += PlayerReset;
            GameManager.OnDead += PlayerDead;
            GameManager.OnRunning += PlayerRunActive;
            GameManager.OnSuperRunning += PlayerSuperRunActive;
        }
        void OnDisable()
        {
            LevelManager.OnNextLevel -= PlayerReset;
            MenuManager.OnResetGame -= PlayerReset;
            GameManager.OnDead -= PlayerDead;
            GameManager.OnRunning -= PlayerRunActive;
            GameManager.OnSuperRunning -= PlayerSuperRunActive;
        }
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            _playerController = GetComponent<PlayerController>();
            _playerInput = GetComponent<PlayerInput>();

            _horizontalMover = new HorizontalMover(this);
            _verticalMover = new VerticalMover(this);
            _jump = new Jump(this);
        }
        void Start()
        {
            _playerController.SavePlayerValues(HorizontalSpeed, VerticalSpeed ,JumpPower);
        }
        void Update()
        {
            if (IsSuperRun)
            {
                GameManager.SetState("SuperRunning");
            }
            if (rb.velocity.y != 0)
            {
                IsJump = false;
                IsHorizontal = false;
            }
            inputHorValue = _playerInput.GetMoveInput();
            IsHorizontal = true;
            OnRun?.Invoke();
            
        }
        void FixedUpdate()
        {
            if (IsJump)
            {
                _jump.Active(JumpPower);
                OnJump?.Invoke();
            }
            if (IsHorizontal)
            {
                _horizontalMover.Active(inputHorValue, HorizontalSpeed, BoundX);
            }
        }
        void PlayerRunActive()
        {
            _verticalMover.Active(VerticalSpeed);
        }
        void PlayerSuperRunActive()
        {
            _verticalMover.Active(SuperRunSpeed);
        }
        void PlayerReset()
        {
            _playerController.ResetPlayerValues();
        }
        void PlayerDead()
        {
            VerticalSpeed = 0;
            JumpPower = 0;
            HorizontalSpeed = 0;
            IsJump = false;
        }
    }

}
