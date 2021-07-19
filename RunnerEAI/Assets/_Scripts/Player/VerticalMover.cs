using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class VerticalMover
    {
        PlayerController _playerController;
        Rigidbody rb;
        public VerticalMover(PlayerController playerController)
        {
            rb = playerController.GetComponent<Rigidbody>();
            _playerController = playerController;
        }
        public void Active(float verticalSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, verticalSpeed);
        }
    }
}

