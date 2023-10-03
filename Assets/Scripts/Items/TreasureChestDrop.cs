namespace Assets.Scripts.Items
{
    using UnityEngine;
    
    public class TreasureChestDrop : MonoBehaviour
    {
        public GameObject ItemToDrop;
        public int TreasureValue;

        private int _quantityOfItemsToShowWhenOpened = 5;


        public void DropItemWhenOpened()
        {
            for (int i = 0; i < _quantityOfItemsToShowWhenOpened; i++)
            {
                Instantiate(ItemToDrop, transform, false);
            }
        }
        
    }
}