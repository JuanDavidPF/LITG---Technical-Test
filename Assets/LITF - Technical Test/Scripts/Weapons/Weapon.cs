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

        [SerializeField] protected WeaponData data;
        [SerializeField] protected string interactableText = "Grab Weapon";
        [SerializeField] protected KeyCode interactableKey = KeyCode.E;
        [SerializeField] protected float minDistancePickUp = 3;
        [SerializeField] protected UnityEvent OnShoot;

        protected virtual void Awake()
        {
            TryGetComponent(out rb);

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
            return true;
        }//Closes Shoot method

    }//Closes Weapon method
}//Closes Namespace declaration
