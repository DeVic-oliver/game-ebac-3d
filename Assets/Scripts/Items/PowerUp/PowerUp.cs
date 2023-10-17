namespace Assets.Scripts.Items.PowerUp
{
    using Assets.Scripts.Player;
    using UnityEngine;
    
    public class PowerUp : MonoBehaviour
    {
        [SerializeField] protected Texture2D _texture;
        [SerializeField] protected float _duration;

        protected virtual void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerTextureChanger textureChanger))
            {
                textureChanger.ChangeTextureTo(_texture, _duration);
                Destroy(gameObject);
            }
        }
    }
}