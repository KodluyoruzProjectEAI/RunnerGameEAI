using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Managers;
using UnityEngine.UI;
using slide;

namespace _coin
{
    public class Coin : MonoBehaviour
    {
        int i = 1;
        SliderController sliderController;
        GameManager gameManager;
        PlayerController playerController;

        private void Awake()
        {
            sliderController = FindObjectOfType<SliderController>();
        }
        void OnTriggerEnter(Collider other)
        {
            playerController = other.GetComponent<PlayerController>();
            if (playerController)
            {
               
                Destroy(gameObject);
                sliderController.Stamina(i);
                               
            }
        }
    }

}
