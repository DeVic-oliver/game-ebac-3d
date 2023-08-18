namespace Assets.Scripts.Player
{
    using UnityEngine;

    public class PlayerHealthAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;


        public void SetIsAliveParamToFalse()
        {
            SetIsAliveParamTo(false);
        }

        public void SetIsAliveParamToTrue()
        {
            SetIsAliveParamTo(true);
        }

        private void SetIsAliveParamTo(bool isAlive)
        {
            _animator.SetBool("isAlive", isAlive);
        }
    }
}