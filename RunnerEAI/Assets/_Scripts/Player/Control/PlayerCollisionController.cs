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
        void Awake()
        {
            _playerController = GetComponent<PlayerController>();
        }
        void OnCollisionEnter(Collision collision)
        {
            switch (collision.collider.tag)
            {
                case "Floor":
                    
                    if (GameManager.currentState == GameManager.GetState("Jump"))
                    {
                        GameManager.SetState("Running");
                    }
                    break;

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
                    if (GameManager.currentState == GameManager.GetState("Win")) 
                    {
                        return; 
                    }
                    SoundManager.Instance.PlayWinMusic();
                    GameManager.SetState("Win");
                    break;
            }
        }
    }
}

