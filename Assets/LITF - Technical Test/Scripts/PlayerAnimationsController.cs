using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    [RequireComponent(typeof(Animator)
    )]
    public class PlayerAnimationsController : MonoBehaviour
    {

        private Animator animator;
        private void Awake()
        {
            TryGetComponent(out animator);

        }//Closes Awake method


        public void ResolveSelectedEmote(AnimatorOverrideController aoc)
        {
            animator.runtimeAnimatorController = aoc;

        }//Closes ResolveSelectedEmote method


        public void PlayEmote()
        {
            animator.Play("Emote");

        }//Closes ResolveSelectedEmote method

    }//Closes PlayerAnimationsController Class
}//Closes Namespace declaration
