namespace Assets.Scripts.Core.Data.JSON
{
    using Assets.Scripts.Core.Data.JSON.DataStructures;
    using Assets.Scripts.Items;
    using Assets.Scripts.Player;
    using System.Collections.Generic;
    using System.IO;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class PlayerDataJSONManipulator : MonoBehaviour
    {
        public PlayerHealth Health;
        public Inventory Inventory;
        public Transform PlayerTransform;

        private static readonly string _fileName = "player_data";


        public void SaveDataIntoJSON()
        {
            List<ItemsCollected> currentItemsData = new();
            foreach (Item item in Inventory.GetItemsFromInventory())
            {
                ItemsCollected itemCollected = new ItemsCollected();
                itemCollected.Type = item.Type;
                itemCollected.Quantity = item.Quantity;
                itemCollected.Value = item.Value;
                currentItemsData.Add(itemCollected);
            }

            PlayerData data = new(Health.CurrentHealth, PlayerTransform.position, SceneManager.GetActiveScene().buildIndex, currentItemsData);
            string json = JsonUtility.ToJson(data);
            string path = GetPath();

            File.WriteAllText(path, json);
        }

        private void Start()
        {
            if (JSONFileExists())
                SetPlayerData();
        }

        private void SetPlayerData()
        {
            PlayerData data = LoadDataFromJSON();
            Health.SetHealth(data.CurrentHealth);
            PlayerTransform.position = data.CurrentPosition;
            foreach (ItemsCollected item in data.CurrentItemsCollected)
            {
                Inventory.AddToInventory(item.Type, item.Quantity, item.Value);
            }
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