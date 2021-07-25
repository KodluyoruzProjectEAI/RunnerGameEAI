using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : CameraData
{
    CameraIdle _cameraIdle;
    public CameraStates state;
    public enum CameraStates
    {
        Start,
        Idle,
        InGame,
        End
    }
    void OnEnable()
    {
        MenuManager.OnCamera += SetStateIdle;
    }
    void Awake()
    {
        _cameraIdle = new CameraIdle(this);
    }
    void Start()
    {
        transform.position = firstPos;
        transform.eulerAngles = firstRot;
    }
    void Update()
    {
        if (transform.position == targetPos)
        {   
            distance = targetPlayer.transform.position - transform.position;
            SetStateRunning();
        }
    }
    void LateUpdate()
    {
        switch (state)
        {
            case CameraStates.Idle:
                _cameraIdle.IdleMOD(targetPos, targetRot);
            break;

            case CameraStates.InGame:
                _cameraIdle.InGameMOD(distance,targetPlayer.transform.position);
            break;

            case CameraStates.End:
                _cameraIdle.EndMOD();
                break;
        }
    }
    void SetStateIdle()
    {
        state = CameraStates.Idle;
    }
    void SetStateRunning()
    {
        state = CameraStates.InGame;
        GameManager.SetState("Running");
    }
}
