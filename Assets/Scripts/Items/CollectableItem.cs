namespace Assets.Scripts.Items
{
    using Assets.Scripts.Core.ScriptableObjects;
    using System.Collections;
    using UnityEngine;

    public class CollectableItem : MonoBehaviour
    {
        public ItemData Data;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Collider _collider;
        [SerializeField] private MeshRenderer _mesh;

        private Coroutine _currentCoroutine;


        protected void TryToGetGameObjectInventoryThenAddDataToItAndAutoDestroy(GameObject obj)
        {
            if(obj.TryGetComponent(out Inventory inventory))
            {
                DisableColliderAndMeshComponents();
                PlayAudio();
                inventory.AddToInventory(Data);

                if(_currentCoroutine == null)
                {
                    _currentCoroutine = StartCoroutine(DestroyObjectAfter());
                }
            }
        }

        private void PlayAudio()
        {
            _audioSource.Play();
        }

        private void DisableColliderAndMeshComponents()
        {
            _collider.enabled = false;
            _mesh.enabled = false;
        }

        private IEnumerator DestroyObjectAfter(float seconds = .5f)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }

    }
}
