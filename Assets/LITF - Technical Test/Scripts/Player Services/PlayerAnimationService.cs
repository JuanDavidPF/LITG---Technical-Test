using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    public class PlayerAnimationService
    {
        private readonly Animator animator;
        private readonly KeyCode emoteKey;
        private bool isEmoting = false;

        public PlayerAnimationService(Animator animator, KeyCode emoteKey = KeyCode.F)
        {
            this.animator = animator;
            this.emoteKey = emoteKey;

        }//Closes PlayerAnimationService constructor


        public void Update()
        {
            if (Input.GetKeyDown(emoteKey)) ToggleEmote();

        }//Closes Update constructor

        public void ToggleEmote()
        {
            if (!animator) return;

            if (isEmoting) StopEmote();
            else Emote();

        }//Closes ToggleEmote method

        public void Emote()
        {
            if (!animator) return;
            isEmoting = true;
            animator.Play("Emote");

        }//Closes Emote method


        public void StopEmote()
        {
            if (!animator) return;
            isEmoting = false;
            animator.Play("Idle");

        }//Closes StopEmote method

        public void SwapController(AnimatorOverrideController aoc)
        {
            if (!animator) return;
            animator.runtimeAnimatorController = aoc;

        }//Closes SwapController method

    }//Closes PlayerInventoryService class
}//Closes Namespace declaration
