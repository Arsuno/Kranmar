using System.Collections;
using _Project.Source.Enemy.Configs;
using _Project.Source.Inventory.Item.ItemTypes;
using _Project.Source.Player;
using UnityEngine;

namespace _Project.Source.Enemy
{
    public class EnemyShootingController : MonoBehaviour
    {
        private GameObject _bulletPrefab;
        private Weapon _equippedWeapon;
        private float _fireRate;

        private bool _isShooting  = false;
        private Coroutine _coroutine;
        
        [SerializeField] private EnemyWeaponSpawner _enemyWeaponSpawner;

        public void Initialize(EnemyConfig config)
        {
            _bulletPrefab = config.BulletPrefab;
            _equippedWeapon = config.Weapon;
            _fireRate = config.FireRate;
        }

        public void StartShooting(PlayerCharacter player)
        {
            if (!_isShooting)
            {
                _coroutine = StartCoroutine(ShootAtPlayer(player));
                _isShooting = true;
            }
        }

        public void StopShooting()
        {
            if (_isShooting && _coroutine != null)
            {
                StopCoroutine(_coroutine);
                _isShooting = false;
            }
        }
        
        private void Shoot(PlayerCharacter player)
        {
            if (player == null) return;

            Vector3 shootDirection = (player.transform.position - _enemyWeaponSpawner.CurrentWeaponObject.transform.position).normalized;
            GameObject bullet = Instantiate(_bulletPrefab, _enemyWeaponSpawner.CurrentWeaponObject.transform.position, Quaternion.LookRotation(shootDirection));

            if (bullet.TryGetComponent(out Projectile projectile))
            {
                projectile.Initialize(10, 20f, shootDirection);
            }
        }
        
        private IEnumerator ShootAtPlayer(PlayerCharacter player)
        {
            while (player != null)
            {
                Shoot(player);
                yield return new WaitForSeconds(1f / _fireRate);
            }
        }
    }
}