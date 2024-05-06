using Payosky.ScriptableObjectsArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Payosky.Utilities
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private ScriptableVariableReference<StringVariable, string> sceneToLoad;
        [SerializeField] private LoadSceneMode loadMode = LoadSceneMode.Single;

        public void LoadScene()
        {
            SceneManager.LoadScene(sceneToLoad.Value, loadMode);

        }//Closes LoadScene method

    }//Closes SceneLoader class

}//Closes Namespace declaration
