using UnityEngine;
using UnityEngine.Events;

namespace Payosky.ScriptableObjectsArchitecture
{
    public abstract class ScriptableVariableListener<TVar, TValue> : MonoBehaviour
    where TVar : ScriptableVariable<TValue>
    {
        [SerializeField] private TVar reference;
        [SerializeField] private bool preInvoke;
        [SerializeField] private UnityEvent<TValue> processes;
        private void Start()
        {
            if (!reference) return;
            if (preInvoke) ExecuteProcesses(reference.Value);
        }//Closes Start method
        private void OnEnable()
        {
            if (!reference) return;
            reference.OnValueChanged += ExecuteProcesses;

        }//Closes OnEnable method

        private void ExecuteProcesses(TValue Value)
        {
            processes?.Invoke(Value);

        }//Closes ExecuteProcesses

        private void OnDisable()
        {
            if (!reference) return;
            reference.OnValueChanged -= ExecuteProcesses;

        }//Closes OnDisable method

    }//Closes ScriptableObjectVariableListener Class
}//Closes Namespace declaration
