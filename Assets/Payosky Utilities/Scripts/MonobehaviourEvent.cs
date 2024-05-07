using UnityEngine;
using UnityEngine.Events;

namespace Payosky.Utilities
{
    public class MonobehaviourEvent : MonoBehaviour
    {
        [System.Flags]
        public enum Trigger
        {
            Awake = 0,
            OnEnable = 1,
            Start = 2,
            Update = 3,
            OnDisable = 4,
            OnDestroy = 5,
            OnMouseEnter = 6,
            OnMouseDown = 7,
            OnMouseOver = 9,
            OnMouseHold = 10,
            OnMouseExit = 11,
            OnMouseUp = 12,

        }

        [SerializeField] private UnityEvent processes;
        [SerializeField] private Trigger trigger;


        private void Awake()
        {
            if (trigger.HasFlag(Trigger.Awake)) processes?.Invoke();
        }//Closes Awake method
        private void Start()
        {
            if (trigger.HasFlag(Trigger.Start)) processes?.Invoke();

        }//Closes Start method

        private void Update()
        {
            if (trigger.HasFlag(Trigger.Update)) processes?.Invoke();

        }//Closes Update method

        private void OnDisable()
        {
            if (trigger.HasFlag(Trigger.OnDisable)) processes?.Invoke();
        }//Closes OnDisable method

    }//Closes MonobehaviourEvent class
}//Closes Namespace declaration
