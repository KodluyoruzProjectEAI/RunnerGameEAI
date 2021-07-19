using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static State GameState;

    public static State currentState{ get { return GameState; } }
    public enum State
    {
        Walking,
        Dead
    }
    void Awake()
    {
        StartSingleton(this);    
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
                GameState = State.Walking;
                break;
            case "Dead":
                GameState = State.Dead;
                break;
        }
    }
}
