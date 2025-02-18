using _Project.Source.Player;
using UnityEngine;
using Zenject;

namespace _Project.Source
{
    public class CompositeRoot : MonoBehaviour
    {
        [Inject] private DiContainer _container;
        
        [SerializeField] private PlayerCharacterFactory playerCharacterFactory;
        
        private void Awake()
        {
            var player = playerCharacterFactory.Create();
            _container.Inject(player);
            
            if (player.TryGetComponent(out ItemUsageHandler itemUsageHandler))
                _container.Inject(itemUsageHandler);
        }
    }
}