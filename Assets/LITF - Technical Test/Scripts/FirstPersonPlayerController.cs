using Payosky.ScriptableObjectsArchitecture;
using UnityEngine;

namespace Payosky.TechnicalTests.LifeIsTheGame
{
    public class FirstPersonPlayerController : MonoBehaviour
    {
        [SerializeField] private ScriptableVariableReference<AnimationVariable, AnimationClip> m_selectedEmote;

    }//Closes FirstPersonPlayerController Class
}//Closes Namespace declaration
