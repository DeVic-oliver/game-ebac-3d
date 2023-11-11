namespace Assets.Scripts.Core.Sound
{
    using UnityEngine;
    using UnityEngine.Audio;
    using UnityEngine.UI;

    public class MasterSoundVolumeToggler : MonoBehaviour
    {
        [SerializeField] private AudioMixer _masterAudioMixer;
        [SerializeField] private Texture2D _soundOn;
        [SerializeField] private Texture2D _soundOff;
        [SerializeField] private RawImage _soundUI;

        private bool _isMasterMixerMuted;


        private void Start()
        {
            _isMasterMixerMuted = true;
        }

        void Update()
        {
            if( Input.GetKeyDown(KeyCode.M) )
            {
                SetMasterMixedMutedState();
                SetSoundUIImage();
                _masterAudioMixer.SetFloat("MasterVolumeParam", GetVolume());
            }
        }

        private void SetMasterMixedMutedState()
        {
            _isMasterMixerMuted = !_isMasterMixerMuted;
        }

        private void SetSoundUIImage()
        {
            if( _isMasterMixerMuted )
            {
                _soundUI.texture = _soundOn;
            }
            else
            {
                _soundUI.texture = _soundOff;
            }
        }

        private float GetVolume()
        {
            return (_isMasterMixerMuted) ? 0 : -80f;
        }
    }
}