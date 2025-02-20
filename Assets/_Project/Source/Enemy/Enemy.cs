using _Project.Source.Enemy.Configs;
using _Project.Source.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Source.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyConfig config;
        
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyWeaponSpawner _enemyWeaponSpawner;
        [SerializeField] private EnemyShootingController _enemyShootingController;

        private PlayerCharacter _player;
        private float _detectionRadius;

        private void Start()
        {
            _detectionRadius = config.DetectionRadius;
            
            _enemyMovement.Initialize(config);
            _enemyWeaponSpawner.SpawnWeaponModel(config.Weapon);
            _enemyShootingController.Initialize(config);
        }

        private void Update()
        {
            if (DetectPlayer())
            {
                _enemyShootingController.StartShooting(_player);
            }
            else
            {
                _enemyShootingController.StopShooting();
                _enemyMovement.StartPatrolling();
            }
        }

        private bool DetectPlayer()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _detectionRadius);
            
            foreach (var col in colliders)
            {
                if (col.TryGetComponent(out PlayerCharacter player))
                {
                    _player = player;
                    return true;
                }
            }

            _player = null;
            return false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _detectionRadius);
        }
    }
}