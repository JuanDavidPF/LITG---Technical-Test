using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payosky.Utilities;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    public class PlayerInventoryService
    {
        private readonly Transform equipmentSocket;
        public Transform EquipmentSocket => equipmentSocket;

        private IEquipable equippedObject;
        public IEquipable EquippedObject
        {
            get { return equippedObject; }
            private set
            {
                value?.OnEquipped();
                equippedObject?.OnDropped();

                equippedObject = value;
            }
        }

        public PlayerInventoryService(Transform equipmentSocket)
        {
            this.equipmentSocket = equipmentSocket;

        }//Closes PlayerInventoryService constructor

        public void Equip(IEquipable equipable)
        {
            if (equipable == null) return;

            EquippedObject = equipable;

        }//Closes Equip method


        public void DropEquipment()
        {
            if (EquippedObject == null) return;
            EquippedObject = null;

        }//Closes DropEqupment Method

    }//Closes PlayerInventoryService class
}//Closes Namespace declaration
