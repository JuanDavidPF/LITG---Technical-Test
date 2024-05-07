using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    public class PlayerReticleService
    {
        private readonly TextMeshProUGUI reticleLabel;

        public PlayerReticleService(TextMeshProUGUI reticleLabel)
        {
            this.reticleLabel = reticleLabel;

        }//Closes PlayerReticleService constructor

        public void DisplayMessage(string message = "", KeyCode key = KeyCode.None)
        {
            if (!reticleLabel) return;

            reticleLabel.text = $"{(key == KeyCode.None ? "" : $"[ {key} ]")} {message}";
            reticleLabel.enabled = true;

        }//Closes DisplayMessage metod

        public void ClearReticle()
        {
            if (!reticleLabel) return;

            reticleLabel.text = "";
            reticleLabel.enabled = false;

        }//Closes ClearReticle metod

    }//Closes PlayerReticleService Class
}//Closes Namespace declaration
