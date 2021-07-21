using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
public class Camera : MonoBehaviour
{
     // private PlayerController _playerController;
     
     private Vector3 firstPos; // position of the cam before we press "tap to play"
     private Vector3 playerPos;
     private Vector3 startingPos; // this is the position reference of the cam while we are in the game and running
     private Vector3 startingPosOffset;
     private Vector3 finishPos;
     Vector3 velocity; //SmoothDamp requires ref velocity
     public Transform PlayerLocation;
     Vector3 Distance;
    
    private void Start()
     {
          firstPos = transform.position;//should this be in the awake instead to make sure we get the first pos ?
          //playerPos = FindObjectOfType<PlayerController>().GetComponent(transform);
          // playerPos = _playerController.transform.position;
          velocity = Vector3.one;
          Distance = transform.position - PlayerLocation.position;
     }
    

     private void Update()
     {
        /*switch (State)
        {
             case GameState.1:

                  StartPos();
                  break;
             case GameState.2:

                  FollowPlayer();
                  break;
             case GameState.3:

                  CrashedCamEffect();
                  break;
             case GameState.4:

                  FinishCam();
                  break;
        }*/
        if (PlayerController.fall== false)
        {
            transform.position = Distance + PlayerLocation.position;
        }
     }

     // State ler ile geçiş yaparız, Sırf Camera için enum state oluşturulabilir
     //İkincil ++ cameralar olabilir , kolay transition icin
     //Start Effect
     void StartPos()
     {
          transform.position = Vector3.SmoothDamp(firstPos, startingPos-startingPosOffset, ref velocity, 0.2f);
     }
          
     //Main Follow
     void FollowPlayer()
     {
          transform.position = Vector3.SmoothDamp(transform.position, playerPos, ref velocity, 0.2f);
     }

     
     //Obstacle and Animation Effects
     //condition passed
     void CrashedCamEffect()
     {
          //pingpong forward and back like in real life crash
     }


     //Finish Effect
     //finish line passed state or condition reference
     void FinishCam()
     {
          //SmoothDamp to front of the character
          transform.position = Vector3.SmoothDamp(transform.position, finishPos, ref velocity, 0.2f);
     }
}
