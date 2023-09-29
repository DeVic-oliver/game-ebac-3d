namespace Assets.Scripts.Core.ScriptableObjects
{
    using Assets.Scripts.Core.Enum.Item;
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "Item_", menuName = "ScriptableObjects/Item", order = 0)]
    public class ItemData : ScriptableObject
    {
        public ItemTypes Type;
        public Sprite Sprite;
        public string Name;
        public string Description;
        public int Value;
    }
}