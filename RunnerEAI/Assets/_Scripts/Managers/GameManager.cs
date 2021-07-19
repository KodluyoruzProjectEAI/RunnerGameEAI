using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static event System.Action OnDead;
    public static State currentState{ get; private set; }
    public enum State
    {
        Walking,
        Dead
    }
    void Awake()
    {
        StartSingleton(this);
        SetState("Walking");
    }
    void Update()
    {
        Debug.Log(currentState);
        switch (currentState) 
        {
            case State.Walking:
                break;

            case State.Dead:
                OnDead?.Invoke();
                break;
        }
    }
    public static State GetState(string get)
    {
        switch (get)
        {
            case "Walking":
                return State.Walking;
         
            case "Dead":
                return State.Dead;
            
            default:
                return State.Walking;
        }
    }
    public static void SetState(string set)
    {
        switch (set)
        {
            case "Walking":
                currentState= State.Walking;
                break;
            case "Dead":
                currentState= State.Dead;
                break;
        }
    }
}
