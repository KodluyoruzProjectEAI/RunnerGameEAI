using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Player
{
    public class PlayerCollisionController : MonoBehaviour
    {
        PlayerController _playerController;
        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
        }
        void OnCollisionEnter(Collision collision)
        {
            switch (collision.collider.tag)
            {
                case "_obstacle":
                    GameManager.SetState("Dead");
                    break;

                case "_finishLine":
                    GameManager.SetState("Win");
                    break;

            }
        }
        void OnCollisionExit(Collision collision)
        {
            switch (collision.collider.tag)
            {
                case "Floor":
                    GameManager.SetState("Running");
                    break;
            }
        }
    }
}

