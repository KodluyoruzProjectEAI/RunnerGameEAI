using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        public static event System.Action OnCamera;
        public static event System.Action OnResetGame;

        [SerializeField] GameObject LoseMenu;
        [SerializeField] GameObject WinMenu;
        [SerializeField] GameObject TapToPlay_PANEL;
        void Start()
        {
            GameManager.OnDead += EnableLoseMenu;
            OnResetGame += DisableLoseMenu;
            GameManager.OnWin += EnableWinMenu;
            //OnResetGame += DisableWinMenu;
        }
        void EnableWinMenu()
        {
           WinMenu.SetActive(true);
        }
        void EnableLoseMenu()
        {
            LoseMenu.SetActive(true);
        }
        void DisableWinMenu()
        {
            WinMenu.SetActive(false);
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

