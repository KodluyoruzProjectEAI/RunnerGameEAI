using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] GameObject LoseMenu;

        void Start()
        {
            GameManager.OnDead += EnableLoseMenu;
            GameManager.OnResetGame += DisableLoseMenu;
        }
        void EnableLoseMenu()
        {
            LoseMenu.SetActive(true);
        }
        void DisableLoseMenu()
        {
            LoseMenu.SetActive(false);
        }
    }
}

