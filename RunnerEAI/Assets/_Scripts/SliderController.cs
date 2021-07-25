using Managers;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace slide
{
    public class SliderController : MonoBehaviour
    {
        public Image coffee;
        private PlayerData _playerData;
        [SerializeField]
        private float stamina;
        private float maxStamina;
        void OnEnable()
        {
            MenuManager.OnResetGame += ResetSlider;    
        }
        void Start()
        {
            _playerData = FindObjectOfType<PlayerData>();
            stamina = 0;
            maxStamina = 100;
        }

        void Update()
        {
            stamina = Mathf.Clamp(stamina, 0, maxStamina);
            coffee.fillAmount = stamina / maxStamina; // fraction needed because fillAmount is 0 to 1 in value
        }

        public void Stamina(int integer)
        {
            if (integer == 1)
            {
                stamina += 25;
            }
            else if (integer == -1 && stamina == maxStamina)
            {
                stamina -= 100;
                StartCoroutine("StartSuperRunning");
               
            }
        }
        IEnumerator StartSuperRunning()
        {
            GameManager.SetState("SuperRunning");
            yield return new WaitForSeconds(_playerData.SuperRunLifeTime);
            GameManager.SetState("Running");
        }
        void ResetSlider()
        {
            stamina = 0;
        }
    }
}

