using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Payosky.Utilities
{
    public class AdvanceAnimationEvent : MonoBehaviour
    {
        [Serializable]
        struct AnimationEventType
        {
            public string key;
            public UnityEvent events;
        }

        [SerializeField] List<AnimationEventType> events = new();

        Dictionary<string, UnityEvent> processesAtlas = new();


        private void Awake()
        {

            foreach (var e in events)
            {
                if (!processesAtlas.ContainsKey(e.key)) processesAtlas.Add(e.key, e.events);
            }
        }//Closes Awake method

        public void ExecuteAnimationEvent(string key)
        {
            UnityEvent process = null; processesAtlas.TryGetValue(key, out process);
            process?.Invoke();
        }//closes ExecuteAnimationEventProcessor method



    }//Closes AdvanceAnimationEvent class
}//Closes Namespace declaration