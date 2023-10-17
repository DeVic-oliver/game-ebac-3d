namespace Assets.Scripts.Player
{
    using System.Collections;
    using UnityEngine;
    
    public class PlayerTextureChanger : MonoBehaviour
    {
        [SerializeField] private Texture2D _defaultTexture;
        [SerializeField] private Material _material;

        private Coroutine _currentCoroutine;


        public void ChangeTextureTo(Texture2D newTexture, float duration)
        {
            if (_currentCoroutine != null)
                StopCurrentCoroutineThenSetItToNull();

            _material.SetTexture("_EmissionMap", newTexture);

            IEnumerator numerator = ResetToDefaultTextureAfterDuration(duration);
            _currentCoroutine = StartCoroutine(numerator);
        }

        private void StopCurrentCoroutineThenSetItToNull()
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }

        private IEnumerator ResetToDefaultTextureAfterDuration(float duration)
        {
            yield return new WaitForSeconds(duration);
            _material.SetTexture("_EmissionMap", _defaultTexture);
        }

    }
}