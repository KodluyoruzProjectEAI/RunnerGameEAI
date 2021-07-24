using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using Player;
public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform targetPlayer;
    [SerializeField] Vector3 firstPos;
    [SerializeField] Vector3 firstRot;
    [Space]
    [SerializeField] Vector3 targetPos;
    [SerializeField] Vector3 targetRot;

    float x, y, z;
    Vector3 velocity,distance;
    bool SmoothMod,NormalMod;
    void OnEnable()
    {
        MenuManager.OnCameraSmooth += StartSmooth;
    }
    void Awake()
    {
        velocity = Vector3.zero;
    }
    void Start()
    {
        transform.position = firstPos;
        transform.eulerAngles = firstRot;
    }
    void Update()
    {
        x = targetPlayer.transform.position.x;
        y = targetPlayer.transform.position.y;
        z = targetPlayer.transform.position.z;
    }
     void LateUpdate()
   {
        if (NormalMod)
        {
            transform.position = new Vector3(x - distance.x, y - distance.y, z - distance.z);
        }
        if (transform.position == targetPos)
        {
            distance = targetPlayer.transform.position - transform.position;
            SmoothMod = false;
            NormalMod = true;
            GameManager.SetState("Running");
        }
        if (SmoothMod)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 0.3f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRot), 10 * Time.deltaTime);
        }
   }
    void StartSmooth()
    {
        SmoothMod = true;
    }

}
