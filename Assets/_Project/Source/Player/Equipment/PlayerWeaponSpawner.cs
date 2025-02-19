using _Project.Source.Inventory.Item.ItemTypes;
using UnityEngine;

namespace _Project.Source.Player
{
    public class PlayerWeaponSpawner : MonoBehaviour //Не очень название, т.к и спавнит и удаляет
    {
        private GameObject _currentWeaponObject;
        
        [SerializeField] private PlayerEquipment _playerEquipment;
        [SerializeField] private Transform _weaponHoldTransform;
        [SerializeField] private Transform _weaponParent;

        private void OnEnable()
        {
            _playerEquipment.OnWeaponEquipped += SpawnWeaponModel;
            _playerEquipment.OnWeaponUnequipped += DestroyWeaponModel;
        }

        private void OnDisable()
        {
            _playerEquipment.OnWeaponEquipped -= SpawnWeaponModel;
            _playerEquipment.OnWeaponUnequipped -= DestroyWeaponModel;
        }

        private void SpawnWeaponModel(Weapon weapon)
        {
            if (_currentWeaponObject != null)
                Destroy(_currentWeaponObject); 
            
            if (weapon.Prefab != null)
                _currentWeaponObject = Instantiate(weapon.Prefab, _weaponHoldTransform.position, _weaponHoldTransform.rotation, _weaponParent);
        }

        private void DestroyWeaponModel()
        {
            if (_currentWeaponObject != null)
                Destroy(_currentWeaponObject);
        }
    }
}