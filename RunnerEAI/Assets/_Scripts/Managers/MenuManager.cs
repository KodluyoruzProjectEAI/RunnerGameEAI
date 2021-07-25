using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        public static event System.Action OnCamera;
        public static event System.Action OnResetGame;

        [SerializeField] GameObject LoseMenu;
       //   [SerializeField] GameObject WinMenu;
        [SerializeField] GameObject TapToPlay_PANEL;
        void Start()
        {
            GameManager.OnDead += EnableLoseMenu;
            OnResetGame += DisableLoseMenu;
       //     GameManager.OnResetGame += DisableWinMenu;
        }
        void EnableWinMenu()
        {
           
        }
        void EnableLoseMenu()
        {
            LoseMenu.SetActive(true);
        }
        void DisableWinMenu()
        {

        }
        void DisableLoseMenu()
        {
            LoseMenu.SetActive(false);
        }

        public void ResetGame()
        {
            GameManager.SetState("Running");
            OnResetGame?.Invoke();
        }
        public void TapToPlay()
        {
            OnCamera?.Invoke();
            TapToPlay_PANEL.SetActive(false);
        }
    }
}

