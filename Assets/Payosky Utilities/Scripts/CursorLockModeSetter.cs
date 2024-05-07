using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Payosky.Utilities
{
    public class CursorLockModeSetter : MonoBehaviour
    {
        [SerializeField] CursorLockMode lockMode;
        public void Set()
        {
            Cursor.lockState = lockMode;
        }//Closes Set

    }//Closes CursorLockModeSetter
}//Closes Namespace declaration
