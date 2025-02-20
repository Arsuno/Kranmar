using _Project.Source.Inventory.Item.ItemTypes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Source.Player
{
    public class PlayerShootingController : MonoBehaviour
    {
        [SerializeField] private PlayerWeaponSpawner _weaponSpawner;
        [SerializeField] private Camera _camera;
        [SerializeField] private PlayerEquipment _playerEquipment;
        
        private Weapon _currentWeapon;
        
        private void Start()
        {
            _playerEquipment.OnWeaponEquipped += OnWeaponEquipped;
        }

        private void OnDestroy()
        {
            _playerEquipment.OnWeaponEquipped -= OnWeaponEquipped;
        }

        private void Update()
        {
            if (_currentWeapon == null /*|| _firePoint == null*/) return;

            if (Mouse.current.leftButton.wasPressedThisFrame) 
            {
                Shoot();
            }
        }
        
        private void OnWeaponEquipped(Weapon weapon)
        {
            _currentWeapon = weapon;
        }

        private void Shoot()
        {
            if (_currentWeapon == null)
                return;
            
            if (_camera == null) return;

            var bulletSpawnTransform = _weaponSpawner.CurrentWeaponObject.transform;
            
            Ray ray = _camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            Vector3 shootDirection;

            if (Physics.Raycast(ray, out RaycastHit hit, 100f)) // Если попали в объект
            {
                shootDirection = (hit.point - bulletSpawnTransform.position).normalized;
                Debug.DrawRay(bulletSpawnTransform.position, shootDirection * 100f, Color.green, 2f); // Зеленый луч, если попали в объект
            }
            else // Если ничего не попалось – стреляем прямо по направлению камеры
            {
                shootDirection = _camera.transform.forward;
                Debug.DrawRay(bulletSpawnTransform.position, shootDirection * 100f, Color.red, 2f); // Красный луч, если не попали в объект
            }
            
            var bullet = Instantiate(
                _currentWeapon.ProjectilePrefab, 
                bulletSpawnTransform.position, 
                Quaternion.LookRotation(shootDirection)
            );
            

            if (bullet.TryGetComponent(out Projectile projectile))
            {
                projectile.Initialize(_currentWeapon.Damage, 20f, shootDirection);
                Debug.Log("Bullet spawned");
            }
        }
    }
}