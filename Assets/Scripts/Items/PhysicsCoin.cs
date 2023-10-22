namespace Assets.Scripts.Items
{
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
    public class PhysicsCoin : CollectableItem
    {
        private void OnCollisionEnter(Collision collision)
        {
            TryToGetGameObjectInventoryThenAddDataToItAndAutoDestroy(collision.gameObject);
        }
    }
}