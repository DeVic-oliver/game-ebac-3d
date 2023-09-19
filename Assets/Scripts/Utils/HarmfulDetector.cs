namespace Assets.Scripts.Utils
{
    using UnityEngine;
    using UnityEngine.Events;

    public class HarmfulDetector : MonoBehaviour
    {
        public UnityEvent OnHarmDetection;


        private void OnTriggerEnter(Collider other)
        {
            GameObject gameObject = other.gameObject;
            if (gameObject.CompareTag("Harmful"))
                OnHarmDetection?.Invoke();
        }

    }
}