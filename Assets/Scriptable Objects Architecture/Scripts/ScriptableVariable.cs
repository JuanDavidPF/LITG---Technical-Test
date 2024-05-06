using System;
using UnityEngine;

namespace Payosky.ScriptableObjectsArchitecture
{
    public class ScriptableVariable<TValue> : ScriptableObject
    {
        [SerializeField] private TValue m_value;

        public TValue Value
        {
            get { return m_value; }
            set
            {
                if (value.Equals(m_value)) return;
                m_value = value;
                InvokeOnChangeEvent();
            }
        }
        public Action<TValue> OnValueChanged;

#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        private void InvokeOnChangeEvent()
        {
            OnValueChanged?.Invoke(Value);

        }//Closes InvokeValueEvent method

    }//Closes ScriptableObjectVariable Class
}//Closes Namespace declaration
