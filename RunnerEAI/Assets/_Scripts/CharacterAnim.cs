using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public class CharacterAnim : MonoBehaviour
    {
        Animator anim;
        PlayerController _playerController;
        void Awake()
        {
            anim = GetComponent<Animator>();
            _playerController = GetComponent<PlayerController>();
        }
        void OnEnable()
        {
            PlayerController.OnJump += JumpAnim;
            PlayerController.OnRun += RunAnim;
        }
        void OnDisable()
        {
            PlayerController.OnJump -= JumpAnim;
            PlayerController.OnRun -= RunAnim;
        }
        void RunAnim()
        {
            anim.SetTrigger("IsRun");
            anim.ResetTrigger("IsJump");
        }
        void JumpAnim()
        {
            anim.SetTrigger("IsJump");
            anim.ResetTrigger("IsRun");
        }

    }
}

