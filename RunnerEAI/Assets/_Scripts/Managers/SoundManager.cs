using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Player;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioClip winSound, winDanceMusic, obstacleCrash1, obstacleCrash2, bodyFall, backgroundAmbiance;
    public AudioSource winMusic;
    void Awake()
    {
        StartSingleton(this);
    }
    void OnEnable()
    {
        MenuManager.OnResetGame += ResetMusic;    
    }
    public void PlayWinMusic()
    {
        winMusic.Play();
    }
    public void PlayClip(AudioClip soundClip,float vol)
    {
        if (soundClip)
        {
            AudioSource.PlayClipAtPoint(soundClip,Camera.main.transform.position,vol);
        }
    }
    void PlayFinishLineMusic()
    {
        PlayClip(winDanceMusic,0.2f);
    }
    void ResetMusic()
    {
        winMusic.Stop();
    }
    // void PlayObstacleCrashSound()
    // {
    //     
    // }

}
