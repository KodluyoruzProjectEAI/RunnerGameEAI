using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMover
    {
        PlayerController _playerController;
        Rigidbody rb;
        
        public PlayerMover(PlayerController playerController)
        {
            rb = playerController.GetComponent<Rigidbody>();
            _playerController = playerController;

        }
        public void Move(float inputHorValue,float horizontalSpeed,float verticalSpeed)
        {
            rb.velocity = new Vector3(horizontalSpeed * inputHorValue, 0, verticalSpeed);    
            //DENEME 1,2,3
        }
    }

}
