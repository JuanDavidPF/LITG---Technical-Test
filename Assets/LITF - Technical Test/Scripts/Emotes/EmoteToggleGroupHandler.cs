using System.Collections.Generic;
using Payosky.ScriptableObjectsArchitecture;
using UnityEngine;
using UnityEngine.UI;

namespace Payosky.TechnicalTests.LifeIsTheGame
{

    public class EmoteToggleGroupHandler : MonoBehaviour
    {


        [SerializeField] private EmoteToggleHandler emoteTogglePrefab;

        [SerializeField] private List<AnimatorOverrideController> emotes = new();

        [SerializeField] private AnimatorOverrideControllerVariable selectedEmoteVariable;
        private List<EmoteToggleHandler> emoteToggleHandlers = new();


        private void Start()
        {
            InitializeEmoteToggles();

        }//Closes Start method

        private void InitializeEmoteToggles()
        {
            if (!emoteTogglePrefab) return;

            foreach (var emote in emotes)
            {
                emoteToggleHandlers.Add(Instantiate(emoteTogglePrefab, transform).Initialize(emote, this));
            }

        }//Closes InitializeEmoteToggles method

        public void OnToggleSelected(AnimatorOverrideController aoc)
        {

            if (selectedEmoteVariable) selectedEmoteVariable.Value = aoc;

        }//Closes OnToggleSelected method

        public bool IsCurrentSelectedToggle(AnimatorOverrideController aoc)
        {

            return (selectedEmoteVariable && selectedEmoteVariable.Value == aoc);

        }//Closes OnToggleSelected method

    }//Closes EmoteToggleGroupHandler Class
}//Closes Namespace declaration
