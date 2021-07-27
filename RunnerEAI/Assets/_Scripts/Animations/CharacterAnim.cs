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
            GameManager.OnJump += JumpAnim;
            GameManager.OnRunning += RunAnim;
            GameManager.OnWin += WinAnim;
            GameManager.OnDead += DeadAnim;
            GameManager.OnStart += IdleAnim;
            GameManager.OnSuperRunning += SuperRunAnim;
        }
        void OnDisable()
        {
            GameManager.OnJump -= JumpAnim;
            GameManager.OnRunning -= RunAnim;
            GameManager.OnWin -= WinAnim;
            GameManager.OnDead -= DeadAnim;
            GameManager.OnStart -= IdleAnim;
            GameManager.OnSuperRunning -= SuperRunAnim;
        }
        void IdleAnim()
        {
            anim.ResetTrigger("IsJump");
            anim.ResetTrigger("IsRun");
            anim.ResetTrigger("IsSuperRun");
            anim.ResetTrigger("IsDead");
            anim.SetTrigger("IsIdle");
        }
        void RunAnim()
        {
            anim.ResetTrigger("IsIdle");
            anim.ResetTrigger("IsSuperRun");
            anim.ResetTrigger("IsJump");
            anim.ResetTrigger("IsDead");
            anim.SetTrigger("IsRun");
        }
        void SuperRunAnim()
        {
            anim.ResetTrigger("IsRun");
            anim.ResetTrigger("IsJump");
            anim.ResetTrigger("IsSuperRun");
            anim.ResetTrigger("IsDead");
            anim.SetTrigger("IsSuperRun");
        }
        void JumpAnim()
        {
            anim.ResetTrigger("IsIdle");
            anim.ResetTrigger("IsRun");
            anim.ResetTrigger("IsSuperRun");
            anim.ResetTrigger("IsDead");
            anim.SetTrigger("IsJump");
        }
        void WinAnim()
        {
            anim.ResetTrigger("IsIdle");
            anim.ResetTrigger("IsRun");
            anim.ResetTrigger("IsSuperRun");
            anim.ResetTrigger("IsDead");
            anim.ResetTrigger("IsJump");
            anim.SetTrigger("IsWin");
        }
        void DeadAnim()
        {
            anim.ResetTrigger("IsIdle");
            anim.ResetTrigger("IsJump");
            anim.ResetTrigger("IsRun");
            anim.ResetTrigger("IsSuperRun");
            anim.SetTrigger("IsDead");
        }

    }
}

