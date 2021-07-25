using Managers;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public class CharacterAnim : MonoBehaviour
    {
        Animator anim;
        void Awake()
        {
            anim = GetComponent<Animator>();
        }
        void OnEnable()
        {
            PlayerController.OnJump += JumpAnim;
            PlayerController.OnRun += RunAnim;
            GameManager.OnDead += DeadAnim;
            GameManager.OnStart += IdleAnim;
            GameManager.OnSuperRunning += SuperRunAnim;
        }
        void OnDisable()
        {
            PlayerController.OnJump -= JumpAnim;
            PlayerController.OnRun -= RunAnim;
            GameManager.OnDead -= DeadAnim;
            GameManager.OnStart -= IdleAnim;
            GameManager.OnSuperRunning -= SuperRunAnim;
        }
        void IdleAnim()
        {
            anim.SetTrigger("IsIdle");
            anim.ResetTrigger("IsRun");
            anim.ResetTrigger("IsJump");
            anim.ResetTrigger("IsDead");
        }
        void RunAnim()
        {
            anim.SetTrigger("IsRun");
            anim.ResetTrigger("IsSuperRun");
            anim.ResetTrigger("IsJump");
            anim.ResetTrigger("IsDead");
        }
        void SuperRunAnim()
        {
            anim.SetTrigger("IsSuperRun");
            anim.ResetTrigger("IsRun");
            anim.ResetTrigger("IsJump");
            anim.ResetTrigger("IsDead");
        }
        void JumpAnim()
        {
            anim.SetTrigger("IsJump");
            anim.ResetTrigger("IsRun");
            anim.ResetTrigger("IsDead");
        }
        void DeadAnim()
        {
            anim.ResetTrigger("IsJump");
            anim.ResetTrigger("IsRun");
            anim.SetTrigger("IsDead");
        }

    }
}

