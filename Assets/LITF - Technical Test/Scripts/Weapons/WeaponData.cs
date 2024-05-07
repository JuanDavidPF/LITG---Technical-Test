using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    [CreateAssetMenu(menuName = "Weapons/Data", fileName = "new Weapon Data")]

    public class WeaponData : ScriptableObject
    {
        public enum Firemode
        {
            automatic,
            semiAutomatic,
        }

        public float firePower = 1000;

        public Sprite crossair;

        public Firemode firemode;

        public float cooldown = .5f;

        public int magazineSize = 24;

        public GameObject bullet;

    }//Closes WeaponData class
}//Closes namespace delaration
