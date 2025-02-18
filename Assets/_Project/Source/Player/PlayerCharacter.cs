using _Project.Source.Inventory;
using _Project.Source.Inventory.Item;
using _Project.Source.Inventory.Item.ItemTypes;
using _Project.Source.Inventory.Item.ItemTypesConfigs;
using _Project.Source.PickupObjects;
using UnityEngine;

namespace _Project.Source.Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        [SerializeField] private Health _health;
        
        [SerializeField] private Transform _weaponHoldTransform;
        [SerializeField] private Transform _weaponParent;
        
        private GameObject _currentWeaponObject;
        private Weapon _equippedWeapon;
        
        public Hotbar Hotbar { get; private set; }

        private void OnDisable()
        {
            Hotbar.OnItemUsedEv -= OnItemUsed;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out PickupObject pickupObject))
                pickupObject.Interact(this);
        }

        public void Initialize(Hotbar hotbar)
        {
            Hotbar = hotbar;
            
            Hotbar.OnItemUsedEv += OnItemUsed;
        }
        
        private void OnItemUsed(HotBarItem item)
        {
            if (item is Weapon weapon)
                EquipWeapon(weapon);

            if (item is HealingItem healingItem)
            {
                Hotbar.RemoveItem(healingItem, 1);
                _health.Heal(healingItem.HealingAmount);
            }
        }

        private void EquipWeapon(Weapon weapon)
        {
            if (_equippedWeapon == weapon)
            {
                UnequipWeapon();
                return;
            }

            _equippedWeapon = weapon;
            SpawnWeaponModel(weapon);
        }

        private void UnequipWeapon()
        {
            if (_equippedWeapon == null) return;
            
            _equippedWeapon = null;

            if (_currentWeaponObject != null)
                Destroy(_currentWeaponObject);
        }

        private void SpawnWeaponModel(Weapon weapon)
        {
            if (_currentWeaponObject != null)
                Destroy(_currentWeaponObject); 
            
            if (weapon.Prefab != null)
                _currentWeaponObject = Instantiate(weapon.Prefab, _weaponHoldTransform.position, _weaponHoldTransform.rotation, _weaponParent);
        }
    }

    public class PlayerEquipment : MonoBehaviour
    {
        
    }

    public class PlayerShootingController : MonoBehaviour
    {
        
    }
}