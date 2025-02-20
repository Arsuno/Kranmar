using _Project.Source.Player;
using UnityEngine;
using Zenject;

namespace _Project.Source
{
    public class CompositeRoot : MonoBehaviour
    {
        private FirstPersonMovement _character;
        private ItemUsageHandler _itemUsageHandler;
        
        [Inject]
        public void Construct(FirstPersonMovement character, ItemUsageHandler itemUsageHandler)
        {
            _character = character;
            _itemUsageHandler = itemUsageHandler;
        }
        
    }
}