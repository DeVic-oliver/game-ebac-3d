namespace Assets.Scripts.Core.Data.JSON.DataStructures
{
    using Assets.Scripts.Core.Enum.Item;
    using System;

    [Serializable]
    public struct ItemsCollected
    {
        public ItemTypes Type;
        public int Quantity;
        public int Value;
    }
}