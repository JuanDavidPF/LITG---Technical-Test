using Payosky.ScriptableObjectsArchitecture;
using UnityEngine;
using UnityEngine.UI;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    [RequireComponent(typeof(Toggle))]
    public class EmoteToggleHandler : MonoBehaviour
    {
        private AnimatorOverrideController emote;
        [SerializeField] private Text toggleLabel;
        private Toggle toggle;
        private EmoteToggleGroupHandler emoteToggleGroupHandler;

        private void Awake()
        {
            TryGetComponent(out toggle);

        }//Closes Awake method

        public EmoteToggleHandler Initialize(AnimatorOverrideController emote, EmoteToggleGroupHandler emoteToggleGroupHandler)
        {
            if (toggleLabel) toggleLabel.text = emote.name;

            this.emote = emote;
            this.emoteToggleGroupHandler = emoteToggleGroupHandler;

            toggle.onValueChanged.AddListener(OnValueChanged);

            return this;

        }//Closes Initialize method

        public void OnSelectedAnimationChanged(AnimatorOverrideController emote)
        {
            toggle.isOn = this.emote == emote;

        }//Closes OnSelectedAnimationChanged method

        private void OnValueChanged(bool value)
        {
            if (value) emoteToggleGroupHandler.OnToggleSelected(emote);
            else if (emoteToggleGroupHandler.IsCurrentSelectedToggle(emote)) toggle.SetIsOnWithoutNotify(true);
        }

        private void OnDestroy()
        {
            toggle.onValueChanged.RemoveListener(OnValueChanged);

        }//Closes OnDestroy method

    }//Closes EmoteToggleHandler Class
}//Closes Namespace declaration
