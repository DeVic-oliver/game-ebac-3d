namespace Assets.Scripts.Items
{
    using Assets.Scripts.Core.ScriptableObjects;
    using DG.Tweening;
    using UnityEngine;
    
    public class TreasureChestDrop : MonoBehaviour
    {
        public TreasureChestItem ItemToDrop;
        public int TreasureValue;
        public GameObject Signifier;
        public Animator Animator;
        public ItemData Item;
        public Collider Collider;

        private int _quantityOfItemsToShowWhenOpened = 5;


        public void DropItemWhenOpened()
        {
            for (int i = 0; i < _quantityOfItemsToShowWhenOpened; i++)
            {
                Instantiate(ItemToDrop.gameObject, transform, false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                Signifier.transform.DOScale(0.8f, 0.4f);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SetSignifierScaleToZero();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.UpArrow) )
            {
                SetSignifierScaleToZero();
                Animator.SetTrigger("open");
                Inventory inventory = other.GetComponent<Inventory>();
                inventory.AddToInventory(Item, TreasureValue);
                Collider.enabled = false;
            }
        }

        private void SetSignifierScaleToZero()
        {
            Signifier.transform.DOScale(0f, 0.4f);
        }

    }
}