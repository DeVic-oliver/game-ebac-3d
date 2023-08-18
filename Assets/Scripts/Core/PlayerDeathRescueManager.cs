namespace Assets.Scripts.Core
{
    using Assets.Scripts.Core.Components.Checkpoint;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.SceneManagement;
    
    public class PlayerDeathRescueManager : MonoBehaviour
    {
        public UnityEvent OnRescuingPlayer;
        [SerializeField] private GameObject _player;
        [SerializeField] private SceneCheckpointsManager _chekpointManager;


        public void WhetherHasCheckpointRespawnPlayerOrReloadSceneIfNotHasCheckpoint()
        {
            if(SceneCheckpointsManager.CurrentCheckpointNumberActive > 0)
            {
                _player.SetActive(false);
                OnRescuingPlayer?.Invoke();
                _chekpointManager.RescuePlayerWhenItDies(_player.transform);
                _player.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

    }
}