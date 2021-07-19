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

        void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _verticalMover = new VerticalMover(this);
            _playerInput = new PlayerInput();
        }
        void FixedUpdate()
        {
           _horizontalMover.Active(_playerInput.GetInput(), HorizontalSpeed ,BoundX);
           _verticalMover.Active(VerticalSpeed);
        }
    }

}
