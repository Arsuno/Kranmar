using UnityEngine;
using Zenject;

namespace _Project.Source.Player
{
    public class PlayerCharacterFactory : IFactory<FirstPersonMovement>
    {
        private readonly FirstPersonMovement _characterPrefab;
        private readonly Transform _spawnPoint;
        private readonly DiContainer _container;
        private FirstPersonMovement _playerInstance; // Кешируем игрока

        public PlayerCharacterFactory(FirstPersonMovement characterPrefab, Transform spawnPoint, DiContainer container)
        {
            _characterPrefab = characterPrefab;
            _spawnPoint = spawnPoint;
            _container = container;
        }

        public FirstPersonMovement Create()
        {
            if (_playerInstance == null)
            {
                _playerInstance = _container.InstantiatePrefabForComponent<FirstPersonMovement>(
                    _characterPrefab, _spawnPoint.position, Quaternion.identity, null
                );
            }

            return _playerInstance;
        }
    }
}