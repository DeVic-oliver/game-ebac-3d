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
            IsColorOn = false;
            SetMaterialEmissionColorToBlack();
        }

        private void SetMaterialEmissionColorToBlack()
        {
            _material.SetColor("_EmissionColor", Color.black);
        }

        private void Awake()
        {
            _material = _meshRenderer.material;
        }

    }
}