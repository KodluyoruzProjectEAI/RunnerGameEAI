using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers 
{
    public class GameManager : Singleton<GameManager>
    {
        public static event System.Action OnResetGame;
        public static event System.Action OnDead;
        public static event System.Action OnWin;
       
        public static State currentState { get; private set; }
        public enum State
        {
            Running,
            Dead
        }
        void Awake()
        {
            StartSingleton(this);
            SetState("Walking");
        }
        void Update()
        {
            switch (currentState)
            {
                case State.Running:
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
                case "Running":
                    return State.Running;

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
                case "Running":
                    currentState = State.Running;
                    break;

                case "Dead":
                    currentState = State.Dead;
                    break;
            }
        }
        public void ResetGame()
        {
            SetState("Running");
            OnResetGame?.Invoke();
        }
    }

}
