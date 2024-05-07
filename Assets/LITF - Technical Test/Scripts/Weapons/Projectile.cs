using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] protected ParticleSystem onHitVFX;
        [SerializeField] private int vfxPoolSize = 5;
        protected Queue<ParticleSystem> vfxPool = new();
        protected Rigidbody rb;

        private void Awake()
        {
            TryGetComponent(out rb);

            if (!onHitVFX) return;
            for (int i = 0; i < vfxPoolSize; i++)
            {
                ParticleSystem vfx = Instantiate(onHitVFX, transform.position, transform.rotation);
                vfx.gameObject.SetActive(false);
                vfxPool.Enqueue(vfx);
            }

        }//Closes Awake method

        protected virtual void EmitParticles()
        {

            ParticleSystem vfx = null;
            if (vfxPool.Count > 0) vfx = vfxPool.Dequeue();
            vfxPool.Enqueue(vfx);

            if (!vfx) return;
            vfx.gameObject.SetActive(true);
            vfx.Stop();
            vfx.gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
            vfx.Play();

        }//Closes EmitParticles method

        public virtual Rigidbody Rigidbody => rb;

        protected abstract void OnCollisionEnter(Collision other);

    }//Closes Projectile Class
}//Closes Namespace declaration
