using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using Player;
public class CameraScript : MonoBehaviour
{
     //TAP to PLAY first screen camera input, get from the PlayerInput
     // private PlayerController _playerController;
     
     private Vector3 firstPos; // position of the cam before we press "tap to play"
     private Vector3 playerPos;
     private Vector3 startingPos; // this is the position reference of the cam while we are in the game and running
     private Vector3 startingPosOffset;
     private Vector3 finishPos;

     private Vector3 firstRot;
     private Vector3 startRot;
     
     Vector3 velocity; //SmoothDamp requires ref velocity
     public Transform PlayerLocation;
     Vector3 Distance;
     

     private void Awake()
     {
          firstPos = new Vector3(4.5f,9f,-9f);
          firstRot = new Vector3(23.8f, -16.7f, -2.5f); //23.8,-16.7,-2.5

          startRot = new Vector3(-6.6f, 3.7f, 0);
     }

     private void Start()
     {
          transform.position = firstPos;
          transform.eulerAngles = firstRot;
          //playerPos = FindObjectOfType<PlayerController>().GetComponent(transform);
          // playerPos = _playerController.transform.position;
          velocity = Vector3.one;
          Distance = transform.position - PlayerLocation.position;
          startingPos = Distance + PlayerLocation.position;
     }
    

     private void Update()
     {
        switch (GameManager.currentState)
        {
             case GameManager.State.Start:
                  
                  //StartPos();
                  break;
             case GameManager.State.Running:
                  GameManager.OnRunning += StartPos;
                  //FollowPlayer();
                  break;
             // case GameState.3:
             //
             //      CrashedCamEffect();
             //      break;
             case GameManager.State.Dead:

                  //FinishCam();
                  break;
        }
        // if (PlayerController.fall== false)
        // {
        //     transform.position = Distance + PlayerLocation.position;
        // }
     }

     // State ler ile geçiş yaparız, Sırf Camera için enum state oluşturulabilir
     //İkincil ++ cameralar olabilir , kolay transition icin
     //Start Effect
     void StartPos()
     {
          transform.position = Vector3.SmoothDamp(firstPos, Distance + PlayerLocation.position, ref velocity, 0.2f);
          transform.eulerAngles = Vector3.SmoothDamp(firstRot, startRot, ref velocity, 0.2f);

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
