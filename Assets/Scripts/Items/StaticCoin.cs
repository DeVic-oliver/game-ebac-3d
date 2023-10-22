namespace Assets.Scripts.Items
{
    using UnityEngine;

    [RequireComponent(typeof(SphereCollider))]
    public class StaticCoin : CollectableItem
    {
        private void OnTriggerEnter(Collider other)
        {
            TryToGetGameObjectInventoryThenAddDataToItAndAutoDestroy(other.gameObject);
        }
    }
}