namespace Assets.Scripts.Core.Data.JSON
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class LastScenePlayerLoader : MonoBehaviour
    {
        public Button LoadButton;


        public void LoadLastSceneSaved()
        {
            if (!PlayerDataJSONManipulator.JSONFileExists())
                return;

            int buldIndex = PlayerDataJSONManipulator.GetLastSceneSaved();
            SceneManager.LoadScene(buldIndex);
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}