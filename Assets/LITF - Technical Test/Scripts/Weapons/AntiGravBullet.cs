using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    public class AntiGravBullet : Projectile
    {
        [SerializeField] private float gravDuration = 1;

        [SerializeField] private ForceMode liftMode;
        [SerializeField] private float liftForce = 0;

        [SerializeField] private ForceMode torqueMode;
        [SerializeField] private float torqueForce = 200;

        [SerializeField] private float dragAmount = 20;
        [SerializeField] private float angularDragAmount = 20;

        private static Dictionary<Rigidbody, GravityModifier> affectedElements = new Dictionary<Rigidbody, GravityModifier>();
        protected override void OnCollisionEnter(Collision other)
        {


            Rigidbody rigidBody = other.gameObject.GetComponent<Rigidbody>();
            if (!rigidBody) return;

            if (!affectedElements.ContainsKey(rigidBody)) affectedElements.Add(rigidBody, new GravityModifier(rigidBody, new Vector2(rigidBody.drag, rigidBody.angularDrag)));

            affectedElements[rigidBody].modifiedBy = this;


            StartCoroutine(RestorePhysicality(rigidBody));
            rigidBody.drag = dragAmount;
            rigidBody.angularDrag = angularDragAmount;
            rigidBody.AddTorque(new Vector3(torqueForce, torqueForce, torqueForce), torqueMode);
            rigidBody.AddForce(Vector3.up * liftForce, liftMode);

            EmitParticles();
        }//Closes On Collision Enter


        private IEnumerator RestorePhysicality(Rigidbody rigidBody)
        {
            if (!rigidBody) yield break;
            yield return new WaitForSeconds(gravDuration);

            affectedElements.TryGetValue(rigidBody, out GravityModifier modifierInfo);

            if (modifierInfo == null || modifierInfo.modifiedBy != this) yield break;

            affectedElements.Remove(rigidBody);
            rigidBody.drag = modifierInfo.originalValues.x;
            rigidBody.angularDrag = modifierInfo.originalValues.y;

        }//Closes RestorePhysicality Coroutine

    }//Closes AntyGravBullet class


    public class GravityModifier
    {
        public AntiGravBullet modifiedBy;
        public Rigidbody modifiedRigidBody;
        public Vector2 originalValues;


        public GravityModifier(Rigidbody modifiedRigidBody, Vector2 originalValues)
        {
            this.modifiedRigidBody = modifiedRigidBody;
            this.originalValues = originalValues;
        }

    }
}//Closes Namespace declaration
