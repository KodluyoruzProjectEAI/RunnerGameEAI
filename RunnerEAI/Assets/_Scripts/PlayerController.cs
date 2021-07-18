using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : PlayerData
    {
        PlayerMover _playerMover;
        PlayerInput _playerInput;
        void Awake()
        {
            _playerMover = new PlayerMover(this);
            _playerInput = new PlayerInput();
        }
        void FixedUpdate()
        {
            _playerMover.Move(_playerInput.GetInput(),HorizontalSpeed,VerticalSpeed);
        }



    }

}
