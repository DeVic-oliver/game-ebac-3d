namespace Assets.Scripts.Core.Components.Checkpoint
{
    using System.Collections.Generic;
    using UnityEngine;


    public class SceneCheckpointsManager: MonoBehaviour
    {
        public static int CurrentCheckpointNumberActive { get; private set; }
        public static int TotalCheckpointsInTheScene { get; private set; }

        public int CurrentActive;

        [SerializeField] private List<CheckpointActivation> _sceneCheckpoints;
        private Dictionary<int, CheckpointActivation> _checkpointsDict = new();



        public static void SetCurrentCheckpointNumber(CheckpointActivation checkpoint)
        {
            CurrentCheckpointNumberActive = checkpoint.CheckpointNumber;
        }

        public static void IncrementCheckpointsInTheScene()
        {
            TotalCheckpointsInTheScene++;
        }

        public void RescuePlayerWhenItDies(Transform playerTransform)
        {
            CheckpointActivation currentActiveCheckpoint = _checkpointsDict[CurrentCheckpointNumberActive];
            Transform checkpointTransform = currentActiveCheckpoint.transform;
            playerTransform.position = checkpointTransform.position;
        }

        private void OnDestroy()
        {
            ClearCheckpointReferences();
        }

        private void ClearCheckpointReferences()
        {
            CurrentCheckpointNumberActive = 0;
            TotalCheckpointsInTheScene = 0;
        }

        private void Start()
        {
            foreach (CheckpointActivation checkpoint in _sceneCheckpoints)
            {
                _checkpointsDict.Add(checkpoint.CheckpointNumber, checkpoint);
            }
        }

        private void Update()
        {
            CurrentActive = CurrentCheckpointNumberActive;
        }

    }

}