using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    [RequireComponent(typeof(Animator))]
    public class EmotePreviewerHandler : MonoBehaviour
    {
        private Animator animator;
        private void Awake()
        {
            TryGetComponent(out animator);

        }//Closes Awake method

        public void OnEmoteSelected(AnimatorOverrideController aoc)
        {

            animator.runtimeAnimatorController = aoc;
            animator.Play("Emote");
        }//Closes OnEmoteSelected method

    }//Closes EmotePreviewerHandler Class
}//Closes Namespace declaration
