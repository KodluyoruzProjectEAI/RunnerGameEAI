using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Managers;

namespace _coin
{
    public class Coin : MonoBehaviour
    {
        PlayerController playerController;
        void OnTriggerEnter(Collider other)
        {
            playerController = other.GetComponent<PlayerController>();
            if (playerController)
            {
                Destroy(gameObject);
                
            }
        }
    }

}
