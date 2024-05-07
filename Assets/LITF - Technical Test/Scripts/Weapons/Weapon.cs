using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Payosky.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Weapon : MonoBehaviour, IInteractable, IEquipable
    {
        private Rigidbody rb;
        private bool isHovered;
        private float currentRate;
        private readonly Queue<Projectile> magazine = new();

        [SerializeField] protected WeaponData data;
        [SerializeField] protected Transform nozzleTransform;

        [SerializeField] protected UnityEvent OnShoot;

        [Space(10)]
        [Header("Interactable Fields")]
        [SerializeField] protected string interactableText = "Grab Weapon";
        [SerializeField] protected KeyCode interactableKey = KeyCode.E;
        [SerializeField] protected float minDistancePickUp = 3;

        protected virtual void Awake()
        {
            TryGetComponent(out rb);
            LoadBulletsPool();

        }//Closes Awake method

        public void OnDropped()
        {
            transform.SetParent(null);
            rb.isKinematic = false;
            rb.AddForce((transform.forward + transform.up) * 5, ForceMode.Impulse);
        }//Closes OnDropped

        public void OnEquipped()
        {
            if (isHovered) PlayerManager.PlayerReticleService.ClearReticle();
            transform.SetParent(PlayerManager.PlayerInventoryService.EquipmentSocket);
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            rb.isKinematic = true;
            isHovered = false;
        }

        public void SendContextualPrompt()
        {
            PlayerManager.PlayerReticleService.DisplayMessage(interactableText, interactableKey);

        }//Closes SendContextualPrompt method


        private void OnMouseEnter()
        {
            if (IsEquipped() || !IsCloseEnough()) return;
            SendContextualPrompt();
            isHovered = true;
        }//Closes OnMouseEnter method

        private void OnMouseExit()
        {
            if (IsEquipped()) return;
            PlayerManager.PlayerReticleService.ClearReticle();
            isHovered = false;
        }//Closes OnMouseExit method

        private void Update()
        {
            if (isHovered)
            {
                HandleEquipping();
                if (!IsCloseEnough()) OnMouseExit();
            }

            if (IsEquipped())
            {
                if (!data) return;

                if ((data.firemode == WeaponData.Firemode.semiAutomatic && Input.GetMouseButtonDown(0)) ||
                 (data.firemode == WeaponData.Firemode.automatic && Input.GetMouseButton(0)))
                    Shoot();

            }
            HandleWeaponRate();
        }//Closes Update Method
        private void HandleWeaponRate()
        {
            if (!data) return;
            if (currentRate > 0) currentRate -= Time.deltaTime;
            else currentRate = 0;

        }//Closes HandleWeaponRate method
        private void HandleEquipping()
        {
            if (IsCloseEnough() && !IsEquipped() && Input.GetKeyDown(interactableKey))
                PlayerManager.PlayerInventoryService.Equip(this);

        }//Closes HandleEquipping method

        public bool IsEquipped()
        {
            return PlayerManager.PlayerInventoryService.EquippedObject == this as IEquipable;

        }//Closes IsEquipped method

        public bool IsCloseEnough()
        {
            return Vector3.Distance(transform.position, PlayerManager.PlayerInventoryService.EquipmentSocket.transform.position) <= minDistancePickUp;
        }//Closes IsCloseEnough method

        protected virtual bool Shoot()
        {
            if (!data) return false;
            if (currentRate > 0) return false;

            currentRate = data.cooldown;
            OnShoot.Invoke();

            Projectile bullet = magazine.Dequeue();
            magazine.Enqueue(bullet);
            LaunchProjectile(bullet);

            return true;
        }//Closes Shoot method


        protected virtual void LaunchProjectile(Projectile bullet)
        {
            if (!bullet) return;
            bullet.Rigidbody.velocity = Vector3.zero;
            bullet.transform.SetPositionAndRotation(nozzleTransform.position, nozzleTransform.rotation);
            bullet.gameObject.SetActive(true);
            bullet.Rigidbody.AddForce(nozzleTransform.forward * data.firePower, ForceMode.Impulse);

        }//CLoses LaunchProjectile ethod

        public void LoadBulletsPool()
        {
            if (!data || !data.bullet || !nozzleTransform) return;

            for (int i = 0; i < data.magazineSize; i++)
            {
                Projectile bullet = Instantiate(data.bullet, nozzleTransform.position, transform.rotation);
                bullet.gameObject.SetActive(false);
                magazine.Enqueue(bullet);
            }

        }//Closes LoadBulletsPool method

    }//Closes Weapon method
}//Closes Namespace declaration
