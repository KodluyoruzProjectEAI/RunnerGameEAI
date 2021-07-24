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
     private Vector3 followPos;

     private Vector3 firstRot;
     private Vector3 startRot;

     private Vector3 defaultPos;
     private Vector3 defaultRot;
     
     Vector3 velocity; //SmoothDamp requires ref velocity
     public Transform PlayerLocation;
     Vector3 Distance;
     

     private void Awake()
     {
          
          firstPos = new Vector3(4.5f,9f,-9f);
          firstRot = new Vector3(23.8f, -16.7f, -2.5f); //23.8,-16.7,-2.5

          startingPos = new Vector3(0, 7f, -9f);
          startRot = new Vector3(20f, 0, 0);
     }

     private void Start()
     {
          transform.position = firstPos;
          transform.eulerAngles = firstRot;
          
          velocity = Vector3.one;
          Distance = PlayerLocation.position - startingPos ;
          
     }
    

     private void Update()
     {
          Debug.Log(GameManager.currentState);
        switch (GameManager.currentState)
        {
             case GameManager.State.Idle:
                  break;
             case GameManager.State.Start:
                  GameManager.OnStart += StartPos;
                  GameManager.OnStart += OnStartingPosition;
                  break;
             case GameManager.State.Running:
                  FollowPlayer();
                  break;
             // case GameState.3:
             //
             //      CrashedCamEffect();
             //      break;
             case GameManager.State.Dead:
                  //FinishCam();
                  break;
        }
        followPos = PlayerLocation.position - Distance;
                          followPos.x = 0;
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
          
          defaultPos = Vector3.SmoothDamp(transform.position, startingPos,ref velocity, 2f);
          defaultRot = Vector3.SmoothDamp(transform.eulerAngles, startRot, ref velocity, 2f);
          transform.position = defaultPos;
          transform.eulerAngles = defaultRot;
     }
          
     //Main Follow
     void FollowPlayer()
     {
          transform.position = followPos;
          transform.eulerAngles = startRot;
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

     void gameStateToRunning()
     {
          GameManager.SetState("Running");
     }
     void OnStartingPosition()
     {
          Invoke("gameStateToRunning",2f);
     }
}
