namespace Assets.Scripts.Items
{
    using Assets.Scripts.Core.ScriptableObjects;
    using UnityEngine;
    
    public class CollectableItem : MonoBehaviour
    {
        public ItemData Data;


        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<Inventory>(out Inventory inventory))
            {
                inventory.AddToInventory(Data);
                Destroy(gameObject);
            }
        }
    }
}