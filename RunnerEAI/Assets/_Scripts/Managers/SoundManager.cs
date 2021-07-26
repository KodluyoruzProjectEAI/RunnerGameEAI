using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private AudioClip obstacleCrash;
    private AudioClip bodyFall;
    private AudioClip backgroundAmbiance;
    
    private void Awake()
    {
        StartSingleton(this);
    }
}
