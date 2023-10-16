namespace Assets.Scripts.Items
{
    using Assets.Scripts.Core.ScriptableObjects;
    using UnityEngine;

    public class CollectableItem : MonoBehaviour
    {
        public ItemData Data;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Inventory inventory))
            {
                inventory.AddToInventory(Data);
                Destroy(gameObject);
            }
        }
    }
}