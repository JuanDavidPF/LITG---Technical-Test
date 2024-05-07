using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{

    public class PlayerManager : MonoBehaviour
    {
        #region Components
        [Header("Components")]
        [SerializeField] private Transform equipmentSocket;
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private TextMeshProUGUI reticleLabel;
        #endregion

        #region Keys
        [Space(10)]
        [Header("Keys")]

        [SerializeField] public KeyCode emoteKey = KeyCode.F;
        #endregion


        #region Managers
        private static PlayerInventoryService playerInventoryService;
        public static PlayerInventoryService PlayerInventoryService => playerInventoryService;

        private static PlayerAnimationService playerAnimationService;
        public static PlayerAnimationService PlayerAnimationService => playerAnimationService;

        private static PlayerReticleService playerReticleService;
        public static PlayerReticleService PlayerReticleService => playerReticleService;


        #endregion

        private void Awake()
        {

            playerAnimationService = new(playerAnimator, emoteKey);
            playerReticleService = new(reticleLabel);
            playerInventoryService = new(equipmentSocket);

        }//Closes Awake method
        Ray ray;
        RaycastHit hit;
        private void Update()
        {
            playerAnimationService.Update();

        }//Closes Update method

        public void ResolveSelectedEmote(AnimatorOverrideController aoc)
        {
            playerAnimationService.SwapController(aoc);

        }//Closes ResolveSelectedEmote method



    }//Closes PlayerAnimationsController Class
}//Closes Namespace declaration