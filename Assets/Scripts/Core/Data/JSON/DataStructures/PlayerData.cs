namespace Assets.Scripts.Core.Data.JSON.DataStructures
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public struct PlayerData
    {
        public int CurrentHealth;
        public Vector3 CurrentPosition;
        public int LastSceneIDSaved;
        public List<ItemsCollected> CurrentItemsCollected;

        public PlayerData(int currentHealth, Vector3 currentPosition, int lastSceneID, List<ItemsCollected> currentItems)
        {
            CurrentHealth = currentHealth;
            CurrentPosition = currentPosition;
            LastSceneIDSaved = lastSceneID;
            CurrentItemsCollected = currentItems;
        }
    }
}