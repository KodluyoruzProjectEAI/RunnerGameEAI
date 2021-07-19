using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player 
{
    public class PlayerInput
    {
        public int GetInput()
        {
            if (Input.touchCount > 0)
            {
                if(Input.GetTouch(0).position.x < Screen.width / 2)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }
    }

}
