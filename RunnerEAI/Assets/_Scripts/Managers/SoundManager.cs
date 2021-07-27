using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioClip winDanceMusic,  obstacleCrash1,obstacleCrash2 , bodyFall,  backgroundAmbiance;

    private void Awake()
    {
        StartSingleton(this);
    }

    private void Start()
    {
        
    }

    public void PlayClip(AudioClip soundClip,float vol)
    {
        if (soundClip)
        {
            AudioSource.PlayClipAtPoint(soundClip,Camera.main.transform.position);
        }
    }

    // void FinishLineMusic()
    // {
    //     ////play music as long as we are in win state
    // }
    //
    // void PlayObstacleCrashSound()
    // {
    //     
    // }
}
