namespace Assets.Scripts.Core.Components.DataPersistence
{
    using UnityEngine;
    
    public class CheckpointColorToggler : MonoBehaviour
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
            _material.SetColor("_EmissionColor", Color.white);
        }

        public void TurnOffCheckpointColor()
        {
            SetMaterialEmissionColorToGray();
            IsColorOn = false;
            SetMaterialEmissionColorToBlack();
        }

        private void SetMaterialEmissionColorToGray()
        {
            _material.SetColor("_EmissionColor", Color.gray);
        }

        private void Awake()
        {
            _material = _meshRenderer.material;
        }

    }
}