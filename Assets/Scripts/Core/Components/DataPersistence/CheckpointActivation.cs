namespace Assets.Scripts.Core.Components.DataPersistence
{
    using UnityEngine;

    [RequireComponent(typeof(Collider), typeof(CheckpointColorToggler))]
    public class CheckpointActivation : MonoBehaviour
    {
        public int CheckpointNumber { get; private set; }

        private CheckpointColorToggler _colorToggler;


        private void Awake()
        {
            SetCheckpointNumberThenIncrementTheCheckpointsInScene();
            _colorToggler = GetComponent<CheckpointColorToggler>();
        }

        private void SetCheckpointNumberThenIncrementTheCheckpointsInScene()
        {
            SetCheckpointNumber();
            SceneCheckpointsManager.IncrementCheckpointsInTheScene();
        }

        private void SetCheckpointNumber()
        {
            CheckpointNumber = SceneCheckpointsManager.TotalCheckpointsInTheScene;
            CheckpointNumber++;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _colorToggler.TurnOnCheckpointColor();
                ChangeCurrentCheckpointActiveNumber();
            }
        }

        private void ChangeCurrentCheckpointActiveNumber()
        {
            SceneCheckpointsManager.SetCurrentCheckpointNumber(this);
        }

        private void Update()
        {
            SetColorOffWhenImNotTheCurrentActiveCheckpoint();
        }

        private void SetColorOffWhenImNotTheCurrentActiveCheckpoint()
        {
            if (_colorToggler.IsColorOn && ImNotTheCurrentCheckpointActive())
                _colorToggler.TurnOffCheckpointColor();
        }

        private bool ImNotTheCurrentCheckpointActive()
        {
            return (CheckpointNumber != SceneCheckpointsManager.CurrentCheckpointNumberActive);
        }
    }
}