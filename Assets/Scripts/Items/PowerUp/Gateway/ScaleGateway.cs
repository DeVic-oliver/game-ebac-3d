namespace Assets.Scripts.Items.PowerUp.Gateway
{
    using UnityEngine;
    using System.Collections;
    
    public class ScaleGateway : MonoBehaviour
    {
        private Vector3 _defaultScale;
        private Coroutine _currentCoroutine;

        public void IncreaseScale(float value, float duration)
        {
            if(_currentCoroutine == null)
            {
                transform.localScale = Vector3.one * value;
                IEnumerator numerator = ResetMoveSpeedAfterDurationEnds(duration);
                _currentCoroutine = StartCoroutine(numerator);
            }
        }

        private IEnumerator ResetMoveSpeedAfterDurationEnds(float duration)
        {
            yield return new WaitForSeconds(duration);
            transform.localScale = _defaultScale;
            _currentCoroutine = null;
        }

        private void Start()
        {
            _defaultScale = transform.localScale;
        }
    }
}