using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : PlayerData
    {
        [SerializeField] float BoundX;
        HorizontalMover _horizontalMover;
        VerticalMover _verticalMover;
        PlayerInput _playerInput;
        public static bool fall;
        Vector3 Direction;
        float inputHorValue;
        private void Start()
        {
            Direction = Vector3.forward;
            fall = false;
        }
        void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _verticalMover = new VerticalMover(this);
            _playerInput = new PlayerInput();
        }
        void Update()
        {
            inputHorValue = _playerInput.GetInput();
        }
        void FixedUpdate()
        {
           _horizontalMover.Active(inputHorValue, HorizontalSpeed ,BoundX);
           _verticalMover.Active(VerticalSpeed);
        }
    }

}
