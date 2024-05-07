using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    public class BlackHoleOrb : Projectile
    {
        [SerializeField] private float lifespan = 10;

        [SerializeField] private float pullForce = 100;

        private void OnEnable()
        {
            StartCoroutine(HandleLifeSpan());

        }//Closes OnEnable mehod

        private void OnDisable()
        {
            StopAllCoroutines();

        }//Closes OnDisable mehod

        protected override void OnCollisionEnter(Collision other)
        {
            rb.isKinematic = true;
            Destroy(other.gameObject);
            EmitParticles();

        }//Closes OnCollisionEnter mehod

        private void OnTriggerStay(Collider other)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (!rb) return;
            Vector3 forceDirection = transform.position - other.transform.position;
            rb.AddForce(pullForce * Time.fixedDeltaTime * forceDirection.normalized);

        }//Closes OnTriggerStay mehod

        private IEnumerator HandleLifeSpan()
        {
            yield return new WaitForSeconds(lifespan);
            gameObject.SetActive(false);

        }//Closes HandleLifeSpan coroutine

    }//Closes BlackHoleOrb class
}//Closes Namespace declaration
