using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public class CharacterAnim : MonoBehaviour
    {
        private Animator anim;
        private void Start()
        {
            anim = GetComponent<Animator>();
        }
        private void Update()
        {
            //if (Input.GetMouseButtonDown(0))
            //{
            //anim.SetBool("isRunnin", false);
            //}
            //else
            //{
            //anim.SetBool("isRunning",true);
            //}
            //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            //{
            //anim.SetBool("isRunnin",true);
            //}
            //else
            //{
            //anim.SetBool("isRunnin", false);
            //}
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("jump");
            }
                
        }
    }
}

