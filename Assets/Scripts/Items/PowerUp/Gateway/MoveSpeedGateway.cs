namespace Assets.Scripts.Items.PowerUp.Gateway
{
    using Assets.Scripts.Player;
    using UnityEngine;
    using System.Collections;
    
    public class MoveSpeedGateway : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _movement;
        private Coroutine _currentCoroutine;

        public void AddValueToMoveSpeed(float value, float duration)
        {
            if(_currentCoroutine == null)
            {
                _movement.AddValueToMoveSpeed(value);
                IEnumerator numerator = ResetMoveSpeedAfterDurationEnds(duration);
                _currentCoroutine = StartCoroutine(numerator);
            }
        }

        private IEnumerator ResetMoveSpeedAfterDurationEnds(float duration)
        {
            yield return new WaitForSeconds(duration);
            _movement.ResetMoveSpeed();
            _currentCoroutine = null;
        }
    }
}