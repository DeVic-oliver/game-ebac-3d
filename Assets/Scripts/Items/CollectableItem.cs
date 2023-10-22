namespace Assets.Scripts.Items
{
    using Assets.Scripts.Core.ScriptableObjects;
    using UnityEngine;

    public class CollectableItem : MonoBehaviour
    {
        public ItemData Data;

        protected void TryToGetGameObjectInventoryThenAddDataToItAndAutoDestroy(GameObject obj)
        {
            if(obj.TryGetComponent(out Inventory inventory))
            {
                inventory.AddToInventory(Data);
                Destroy(gameObject);
            }
        }
    }
}
