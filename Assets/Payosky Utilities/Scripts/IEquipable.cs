using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Payosky.Utilities
{
    public interface IEquipable
    {

        void OnEquipped();

        void OnDropped();

        bool IsEquipped();

    }//Closes IEquiplable interface
}//Closes Namespace declaration
