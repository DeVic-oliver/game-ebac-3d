namespace Assets.Scripts.Items
{
    using DG.Tweening;
    using System.Collections;
    using UnityEngine;
    
    public class TreasureChestItem : MonoBehaviour
    {

        private void Start()
        {
            transform.localScale = Vector3.zero;
            float xPosition = Random.Range(-1f, 1f);
            float zPosition = Random.Range(-1f, 1f);
            transform.localPosition = new Vector3(xPosition, 0.75f,zPosition);
            StartCoroutine(nameof(AnimateSpawn));
        }

        private IEnumerator AnimateSpawn()
        {
            float delayToDoExitAnimation = 0.3f;
            yield return new WaitForSeconds(delayToDoExitAnimation);
            ChangeScaleByTween(.4f, 0.3f);
            StartCoroutine(nameof(AnimateExit));
        }

        private IEnumerator AnimateExit()
        {
            float delayToDoExitAnimation = 0.8f;
            yield return new WaitForSeconds(delayToDoExitAnimation);
            transform.DOMoveY(1.5f, 1.2f);
            ChangeScaleByTween(0, 0.3f);
        }

        private void ChangeScaleByTween(float endScaleValue, float tweenDuration)
        {
            transform.DOScale(endScaleValue, tweenDuration);
        }

    }
}