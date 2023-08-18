namespace Assets.Scripts.Player
{
    using UnityEngine;
    using UnityEngine.Events;

    public class PlayerDeathAnimationEvents : MonoBehaviour
    {
        public UnityEvent OnDeathKeyFrame;
        
        
        public void InvokeEventsWhenReachesEventKeyFrame()
        {
            OnDeathKeyFrame?.Invoke();
        }
    }
}