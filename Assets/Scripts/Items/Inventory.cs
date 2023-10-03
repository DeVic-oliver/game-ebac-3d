namespace Assets.Scripts.Items
{
    using Assets.Scripts.Core.Components;
    using Assets.Scripts.Core.Enum.Item;
    using Assets.Scripts.Core.ScriptableObjects;
    using System.Collections.Generic;
    using UnityEngine;
    using static UnityEditor.LightingExplorerTableColumn;

    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryUIManager _inventoryUI;

        private Dictionary<ItemTypes, Item> _items;


        private void Awake()
        {
            _items = new();
        }

        public void AddToInventory(ItemData data)
        {
            ItemTypes type = data.Type;
            if (_items.ContainsKey(type))
            {
                _items[type].IncrementQuantity();
            }
            else
            {
                CreateItemToAdd(data, 1);
            }
            _inventoryUI.UpdateUICount(_items[type]);
        }

        public void AddToInventory(ItemData data, int quantity)
        {
            ItemTypes type = data.Type;
            if (_items.ContainsKey(type))
            {
                _items[data.Type].AddQuantity(quantity);
            }
            else
            {
                CreateItemToAdd(data, quantity);
            }
            _inventoryUI.UpdateUICount(_items[type]);
        }

        private void CreateItemToAdd(ItemData data, int quantity = 1)
        {
            Item newItem = new(data, quantity);
            _items.Add(newItem.GetItemType(), newItem);
        }

        public int UseItem(ItemTypes type)
        {
            if(_items.ContainsKey(type))
            {
                Item item = _items[type];
                item.DecrementQuantity();
                DeleteKeyIfItemQuantityReachesZero(type, item);
                _inventoryUI.UpdateUICount(item);
                return item.GetItemValue();
            }
            return 0;
        }

        private void DeleteKeyIfItemQuantityReachesZero(ItemTypes type, Item item)
        {
            if (item.Quantity <= 0)
                _items.Remove(type);
        }

    }
}