using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    public class Grenade : Projectile
    {
        private bool isActive;
        [SerializeField] protected float minColissionForce = 0f;
        [SerializeField] private float force;
        [SerializeField] private float radius;
        [SerializeField] private float lift;

        protected override void OnCollisionEnter(Collision other)
        {
            if (!isActive) return;
            if (other.relativeVelocity.magnitude > minColissionForce) Explotion();
        }//Closes OnColissionEnter method

        private void Explotion()
        {
            foreach (Collider hit in Physics.OverlapSphere(transform.position, radius))
            {
                Rigidbody rigidBody = hit.GetComponent<Rigidbody>();
                if (rigidBody) rigidBody.AddExplosionForce(force, transform.position, radius, lift);
            }
            isActive = false;
            EmitParticles();

        }//Closes Explotion method

        private void OnEnable()
        {
            isActive = true;

        }//Closes OnEnable method



    }//Closes BlackHoleOrb class
}//Closes Namespace declaration