using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    public class BlackHoleGun : Weapon
    {


        protected override bool Shoot()
        {
            if (!base.Shoot()) return false;

            Debug.Log("Shoot");
            return true;

        }//Closes Shoot method

    }//Closes BlackHoleGun class
}//Closes Namespace declaration

