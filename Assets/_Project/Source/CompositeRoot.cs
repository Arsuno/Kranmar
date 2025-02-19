using _Project.Source.Player;
using UnityEngine;
using Zenject;

namespace _Project.Source
{
    public class CompositeRoot : MonoBehaviour
    {
        [Inject] private IFactory<FirstPersonMovement> _characterFactory;
        [Inject] private IFactory<ItemUsageHandler> _itemUsageFactory;

        private void Awake()
        {
            var player = _characterFactory.Create();
            var itemUsageHandler = _itemUsageFactory.Create();
        }
    }
}