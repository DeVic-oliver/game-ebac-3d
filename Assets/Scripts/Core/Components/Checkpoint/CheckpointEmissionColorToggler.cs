namespace Assets.Scripts.Core.Components.Checkpoint
{
    using UnityEngine;
    
    public class CheckpointEmissionColorToggler : MonoBehaviour
    {
        public bool IsColorOn { get; private set; }

        [SerializeField] private MeshRenderer _meshRenderer;
        private Material _material;

        public void TurnOnCheckpointColor()
        {
            IsColorOn = true;
            SetMaterialEmissionColorToWhite();
        }

        private void SetMaterialEmissionColorToWhite()
        {
            _material.SetColor("_EmissionColor", Color.white * 3);
        }

        public void TurnOffCheckpointColor()
        {
            IsColorOn = false;
            SetMaterialEmissionColorToBlack();
        }

        private void SetMaterialEmissionColorToBlack()
        {
            _material.SetColor("_EmissionColor", Color.white * 0);
        }

        private void Awake()
        {
            _material = _meshRenderer.material;
        }

    }
}