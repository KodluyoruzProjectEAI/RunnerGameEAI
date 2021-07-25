﻿using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using Player;
public class CameraIdle : MonoBehaviour
{
    CameraController _cameraController;
    float x, y, z;
    Vector3 velocity;
    public CameraIdle(CameraController cameraController)
    {
        _cameraController = cameraController;
        velocity = Vector3.zero;
    }
    public void IdleMOD(Vector3 targetPos, Vector3 targetRot)
    {
        _cameraController.transform.position = Vector3.SmoothDamp(_cameraController.transform.position, targetPos, ref velocity, 0.3f);
        _cameraController.transform.rotation = Quaternion.Lerp(_cameraController.transform.rotation, Quaternion.Euler(targetRot), 10 * Time.deltaTime);
    }
    public void InGameMOD(Vector3 distance,Vector3 targetPosition)
    {
        _cameraController.transform.position = new Vector3(targetPosition.x - distance.x, targetPosition.y - distance.y, targetPosition.z-9f);
    }
    public void EndMOD()
    {

    }
}
