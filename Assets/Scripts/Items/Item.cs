namespace Assets.Scripts.Items
{
    using Assets.Scripts.Core.Enum.Item;
    using Assets.Scripts.Core.ScriptableObjects;


    public class Item
    {
        public int Quantity { get; private set; }

        private ItemData _data;


        public Item(ItemData data, int quantity)
        {
            _data = data;
            Quantity = quantity;
        }

        public void IncrementQuantity()
        {
            Quantity++;
        }

        public void DecrementQuantity()
        {
            if(Quantity > 0)
                Quantity--;
        }

        public int GetItemValue()
        {
            return _data.Value;
        }

        public ItemTypes GetItemType()
        {
            return _data.Type;
        }
    }
}