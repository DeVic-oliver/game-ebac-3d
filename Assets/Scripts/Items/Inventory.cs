namespace Assets.Scripts.Items
{
    using Assets.Scripts.Core.Components;
    using Assets.Scripts.Core.Enum.Item;
    using Assets.Scripts.Core.ScriptableObjects;
    using System.Collections.Generic;
    using UnityEngine;


    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryUIManager _inventoryUI;

        private Dictionary<ItemTypes, Item> _items;


        public Dictionary<ItemTypes, Item>.ValueCollection GetItemsFromInventory()
        {
            return _items.Values;
        }
        
        public void AddToInventory(ItemTypes type, int quantity, int value)
        {
            if (_items.ContainsKey(type))
            {
                _items[type].IncrementQuantity();
            }
            else
            {
                CreateItemToAdd(type, quantity, value);
            }
            _inventoryUI.UpdateUICount(_items[type]);
        }

        public void AddToInventory(ItemData data, int quantity = 1)
        {
            ItemTypes type = data.Type;
            if (_items.ContainsKey(type))
            {
                _items[type].IncrementQuantity();
            }
            else
            {
                CreateItemToAdd(data, quantity);
            }
            _inventoryUI.UpdateUICount(_items[type]);
        }

        private void CreateItemToAdd(ItemData data, int quantity)
        {
            Item newItem = new(data, quantity);
            AddItemToList(newItem);
        }

        private void CreateItemToAdd(ItemTypes type, int quantity, int value)
        {
            Item newItem = new(type, quantity, value);
            AddItemToList(newItem);
        }

        private void AddItemToList(Item item)
        {
            _items.Add(item.Type, item);
        }

        public int UseItem(ItemTypes type)
        {
            if(_items.ContainsKey(type))
            {
                Item item = _items[type];
                item.DecrementQuantity();
                DeleteKeyIfItemQuantityReachesZero(type, item);
                _inventoryUI.UpdateUICount(item);
                return item.Value;
            }
            return 0;
        }

        private void DeleteKeyIfItemQuantityReachesZero(ItemTypes type, Item item)
        {
            if (item.Quantity <= 0)
                _items.Remove(type);
        }

        private void Awake()
        {
            _items = new();
        }

    }
}