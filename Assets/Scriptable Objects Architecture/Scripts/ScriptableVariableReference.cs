using System;
using UnityEngine;

namespace Payosky.ScriptableObjectsArchitecture
{
    [Serializable]
    public class ScriptableVariableReference<TVar, TValue> where TVar : ScriptableVariable<TValue>
    {
        public bool UseConstant = true;
        public TValue ConstantValue;
        public TVar Variable;

        public ScriptableVariableReference() { }

        public ScriptableVariableReference(TValue value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public TValue Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        public static implicit operator TValue(ScriptableVariableReference<TVar, TValue> reference)
        {
            return reference.Value;
        }

    }//Closes ScriptableVariableReference class
}//Closes Namespace declaration
