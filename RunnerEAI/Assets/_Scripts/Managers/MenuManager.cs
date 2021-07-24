using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] GameObject LoseMenu;
     //   [SerializeField] GameObject WinMenu;
        [SerializeField] GameObject TapToPlay_PANEL;
        void Start()
        {
            GameManager.OnDead += EnableLoseMenu;
            GameManager.OnResetGame += DisableLoseMenu;
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

        public void TapToPlay()
        {
            GameManager.SetState("Running");
            TapToPlay_PANEL.SetActive(false);
        }
    }
}

