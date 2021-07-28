using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Player;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioClip winSound, winDanceMusic, obstacleCrash1, obstacleCrash2, bodyFall, backgroundAmbiance;
    public AudioSource winMusic,runMusic;
    void Awake()
    {
        StartSingleton(this);
    }
    void OnEnable()
    {
        MenuManager.OnResetGame += ResetMusic;    
    }
    void Update()
    {
        switch (GameManager.currentState)
        {
            case GameManager.State.Running:
                RunMusic(1);
            break;

            case GameManager.State.SuperRunning:
                RunMusic(1.5f);
            break;
        }    
    }
    public void PlayWinMusic()
    {   
        winMusic.Play();
    }
    public void RunMusic(float pitchValue)
    {
        runMusic.pitch = pitchValue;
        runMusic.Play();
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
