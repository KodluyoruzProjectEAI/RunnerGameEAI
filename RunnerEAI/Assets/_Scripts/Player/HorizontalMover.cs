using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class HorizontalMover
    {
        PlayerController _playerController;
        Rigidbody rb;
        
        public HorizontalMover(PlayerController playerController)
        {
            rb = playerController.GetComponent<Rigidbody>();
            _playerController = playerController;

        }
        public void Active(float inputHorValue,float horizontalSpeed)
        {
            rb.velocity = new Vector3(horizontalSpeed * inputHorValue, 0, 0);    
        }
        public void Active()
        {

        }
    }

}
