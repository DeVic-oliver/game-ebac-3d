namespace Assets.Scripts.Core.Components
{
    using Assets.Scripts.Core.Enum.Item;
    using Assets.Scripts.Items;
    using TMPro;
    using UnityEngine;
    
    public class InventoryUIManager : MonoBehaviour
    {
        public TextMeshProUGUI HealthItemTMP;
        public TextMeshProUGUI CoinItemTMP;


        public void UpdateUICount(Item item)
        {
            if(ItemTypes.HeatlhCoin == item.Type)
            {
                HealthItemTMP.text = item.Quantity.ToString();
                return;
            }
            
            CoinItemTMP.text = item.Quantity.ToString();
        }

    }
}