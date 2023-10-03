namespace Assets.Scripts.Items
{
    using UnityEngine;
    using UnityEngine.Events;
    
    public class TreasureChestOpenEvents : MonoBehaviour
    {
        public UnityEvent OnTreasureChestOpen;


        public void FireEventsWhenChestOpenAnimationComplete()
        {
            OnTreasureChestOpen?.Invoke();
        }
    }
}