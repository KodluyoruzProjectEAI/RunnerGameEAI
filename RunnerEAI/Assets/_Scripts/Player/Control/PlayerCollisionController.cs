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
                    int i =Random.Range(0, 2);
                    if (i == 0)
                    {
                        SoundManager.Instance.PlayClip(SoundManager.Instance.obstacleCrash1,0.5f);
                    }
                    else
                    {
                        SoundManager.Instance.PlayClip(SoundManager.Instance.obstacleCrash2,0.5f);
                    }
                    break;
                case "_finishLine":
                    GameManager.SetState("Win");
                    SoundManager.Instance.PlayClip(SoundManager.Instance.winDanceMusic,0.5f);
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

