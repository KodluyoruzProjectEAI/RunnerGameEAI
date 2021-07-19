using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : PlayerData
    {
        HorizontalMover _horizontalMover;
        PlayerInput _playerInput;
        void Awake()
        {
            _horizontalMover= new HorizontalMover(this);
            _playerInput = new PlayerInput();
        }
        void FixedUpdate()
        {
           _horizontalMover.Active(_playerInput.GetInput(),HorizontalSpeed);
        }
    }

}
