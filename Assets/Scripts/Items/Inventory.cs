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
                Item newItem = new(data, 1);
                _items.Add(type, newItem);
            }
            _inventoryUI.UpdateUICount(_items[type]);
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