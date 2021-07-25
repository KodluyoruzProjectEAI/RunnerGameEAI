using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Image coffee;
    
    private float stamina;
    private float maxStamina;
    
    void Start()
    {
        stamina = 0;
        maxStamina = 100;
    }

    void Update()
    {
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
        coffee.fillAmount =stamina / maxStamina; // fraction needed because fillAmount is 0 to 1 in value
    }

    public void Stamina(int integer)
    {
        if (integer == 1)
        {
            stamina += 25;
        }
        else if (integer == -1)
        {
            stamina -= 25;
        } 
    }
}
