using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    public class GrenadeLauncher : Weapon
    {
        protected override bool Shoot()
        {
            if (!base.Shoot()) return false;

            Debug.Log("Shoot");
            return true;

        }//Closes Shoot method


    }//Closes GrenadeLauncher class
}//Closes Namespace declaration
