namespace Assets.Scripts.Items
{
    using Assets.Scripts.Core.Enum.Item;
    using Assets.Scripts.Core.ScriptableObjects;


    public class Item
    {
        public ItemTypes Type { get; private set; }
        public int Value { get; private set; }  
        public int Quantity { get; private set; }


        public Item(ItemData data, int quantity)
        {
            Type = data.Type;
            Value = data.Value;
            Quantity = quantity;
        }

        public Item(ItemTypes type, int quantity, int value)
        {
            Type = type;
            Value = value;
            Quantity = quantity;
        }

        public void AddQuantity(int value)
        {
            Quantity += value;
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
    }
}