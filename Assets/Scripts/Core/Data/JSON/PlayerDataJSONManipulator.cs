namespace Assets.Scripts.Core.Data.JSON
{
    using Assets.Scripts.Core.Data.JSON.DataStructures;
    using Assets.Scripts.Player;
    using System.IO;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class PlayerDataJSONManipulator : MonoBehaviour
    {
        public PlayerHealth Health;
        public Transform PlayerTransform;

        private static readonly string _fileName = "player_data";


        public void SaveDataIntoJSON()
        {
            PlayerData data = new PlayerData();
            data.CurrentPosition = PlayerTransform.position;
            data.CurrentHealth = Health.CurrentHealth;
            data.LastSceneIDSaved = SceneManager.GetActiveScene().buildIndex;

            string json = JsonUtility.ToJson(data);
            string path = GetPath();

            File.WriteAllText(path, json);
        }

        private void Awake()
        {
            if (JSONFileExists())
                SetPlayerData();
        }

        private void SetPlayerData()
        {
            PlayerData data = LoadDataFromJSON();
            Health.SetHealth(data.CurrentHealth);
            PlayerTransform.position = data.CurrentPosition;
        }

        private static PlayerData LoadDataFromJSON()
        {
            string path = GetPath();
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson <PlayerData>(json);
        }

        public static bool JSONFileExists()
        {
            string path = GetPath();
            return File.Exists(path);
        }

        public static string GetPath()
        {
            string path = Path.Combine(Application.persistentDataPath, _fileName);
            return path;
        }

        public static int GetLastSceneSaved()
        {
            PlayerData data = LoadDataFromJSON();
            return data.LastSceneIDSaved;
        }

    }
}