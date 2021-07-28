using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Player;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioClip winSound, winDanceMusic, obstacleCrash1, obstacleCrash2, bodyFall, backgroundAmbiance;
    public AudioSource winMusic,runMusic,superRunMusic;
    void Awake()
    {
        StartSingleton(this);
    }
    void OnEnable()
    {
        MenuManager.OnResetGame += AllResetMusic;    
    }
    void Update()
    {
        switch (GameManager.currentState)
        {
            case GameManager.State.Running:
                RunMusic();
                break;
            case GameManager.State.Jump:
                AllResetMusic();
                break;
            case GameManager.State.SuperRunning:
                SuperRunMusic();
            break;
            case GameManager.State.Dead:
                AllResetMusic();
                break;
        }    
    }
    public void RunMusic()
    {
        if (runMusic.isPlaying) 
        {
            return;
        }
        AllResetMusic();
        runMusic.Play();
    }
    public void SuperRunMusic()
    {
        if (superRunMusic.isPlaying)
        {
            return;
        }
        AllResetMusic();
        superRunMusic.Play();
    }
    public void PlayWinMusic()
    {
        AllResetMusic();
        winMusic.Play();
    }
    void AllResetMusic() 
    { 
        winMusic.Stop();
        runMusic.Stop();
        superRunMusic.Stop();
    }
    // void PlayObstacleCrashSound()
    // {
    //     
    // }
    public void PlayClip(AudioClip soundClip, float vol)
    {
        if (soundClip)
        {
            AudioSource.PlayClipAtPoint(soundClip, Camera.main.transform.position, vol);
        }
    }
    void PlayFinishLineMusic()
    {
        PlayClip(winDanceMusic, 0.2f);
    }
}
