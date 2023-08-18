namespace Assets.Scripts.Core.Components.DataPersistence
{
    using UnityEngine;
    
    public class CheckpointColorToggler : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        private Material _material;


        public void TurnOnCheckpointColor()
        {
            SetMaterialEmissionColorToWhite();
        }

        private void SetMaterialEmissionColorToWhite()
        {
            _material.SetColor("_EmissionColor", Color.white);
        }

        public void TurnOffCheckpointColor()
        {
            SetMaterialEmissionColorToGray();
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