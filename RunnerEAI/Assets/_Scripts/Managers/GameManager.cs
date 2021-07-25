using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers 
{
    public class GameManager : Singleton<GameManager>
    {
        public static event System.Action OnStart;
        public static event System.Action OnRunning;
        public static event System.Action OnSuperRunning;

        public static event System.Action OnDead;
        public static event System.Action OnWin;

        public static State currentState { get; private set; }
        public enum State
        {
            Start,
            Running,
            SuperRunning,
            Dead
        }
        void Awake()
        {
            StartSingleton(this);
            SetState("Start");
        }
        void Update()
        {
            switch (currentState)
            {
                case State.Start:
                    OnStart?.Invoke();
                    break;
                case State.Running:
                    OnRunning?.Invoke();
                    break;
                case State.SuperRunning:
                    OnSuperRunning?.Invoke();
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
                case "Start":
                    return State.Start;
                
                case "Running":
                    return State.Running;

                case "SuperRunning":
                    return State.SuperRunning;

                case "Dead":
                    return State.Dead;

                default:
                    return State.Running;
            }
        }
        public static void SetState(string set)
        {
            switch (set)
            {
                case "Start":
                    currentState = State.Start;
                    break;

                case "Running":
                    currentState = State.Running;
                    break;

                case "SuperRunning":
                    currentState = State.SuperRunning;
                    break;

                case "Dead":
                    currentState = State.Dead;
                    break;
            }
        }
    }

}
