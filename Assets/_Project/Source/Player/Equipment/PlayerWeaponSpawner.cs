using _Project.Source.Inventory.Item.ItemTypes;
using UnityEngine;

namespace _Project.Source.Player
{
    public class PlayerWeaponSpawner : MonoBehaviour //Не очень название, т.к и спавнит и удаляет
    {
        [SerializeField] private PlayerEquipment _playerEquipment;
        [SerializeField] private Transform _weaponHoldTransform;
        [SerializeField] private Transform _weaponParent;
        
        public GameObject CurrentWeaponObject { get; private set; }

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
            if (CurrentWeaponObject != null)
                Destroy(CurrentWeaponObject); 
            
            if (weapon.Prefab != null)
                CurrentWeaponObject = Instantiate(weapon.Prefab, _weaponHoldTransform.position, _weaponHoldTransform.rotation, _weaponParent);
        }

        private void DestroyWeaponModel()
        {
            if (CurrentWeaponObject != null)
                Destroy(CurrentWeaponObject);
        }
    }
}