using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace PlayerCollision
{
    public class PlayerCollisionController : MonoBehaviour
    {
        
        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("_obstacle"))
            {
                GameManager.SetState("Dead");
                Debug.Log("Çarptı");
            }
            if (collision.collider.CompareTag("_finishLine"))
            {
                GameManager.SetState("Win");
                Debug.Log("Level Complete");
            }
        }
    }
}

