using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    public class GrenadeLauncher : Weapon
    {
        protected override void LaunchProjectile(Projectile bullet)
        {
            if (!bullet) return;
            bullet.Rigidbody.velocity = Vector3.zero;
            bullet.transform.SetPositionAndRotation(nozzleTransform.position, nozzleTransform.rotation);
            bullet.gameObject.SetActive(true);
            bullet.Rigidbody.AddForce((nozzleTransform.forward + (Vector3.up / 4)) * data.firePower, ForceMode.Impulse);

        }//CLoses LaunchProjectile ethod

    }//Closes GrenadeLauncher class
}//Closes Namespace declaration
