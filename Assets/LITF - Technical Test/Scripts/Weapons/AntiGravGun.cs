using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    public class AntiGravGun : Weapon
    {

        protected override bool Shoot()
        {
            if (!base.Shoot()) return false;

            Debug.Log("Shoot");
            return true;

        }//Closes Shoot method

    }//Closes AntiGravGun class
}//Closes Namespace declaration
