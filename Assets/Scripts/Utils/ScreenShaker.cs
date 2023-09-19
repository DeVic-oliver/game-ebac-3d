namespace Assets.Scripts.Utils
{
    using Cinemachine;
    using System.Collections;
    using UnityEngine;

    public class ScreenShaker : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachine;
        [SerializeField] private float _amplitudeGain = 3f;
        
        private CinemachineBasicMultiChannelPerlin _multiChannelPerlin;
        private Coroutine _coroutine;


        public void ShakeCamera()
        {
            if (_coroutine != null)
                return;

            _coroutine = StartCoroutine(nameof(StartCameraShaking));
        }

        private IEnumerator StartCameraShaking()
        {
            _multiChannelPerlin.m_AmplitudeGain = _amplitudeGain;

            yield return new WaitForSeconds(.3f);
            
            SetAmplitudeGainToZero();
            _coroutine = null;
        }

        void Start()
        {
            _multiChannelPerlin = _cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            SetAmplitudeGainToZero();
        }

        private void SetAmplitudeGainToZero()
        {
            _multiChannelPerlin.m_AmplitudeGain = 0;
        }

    }
}