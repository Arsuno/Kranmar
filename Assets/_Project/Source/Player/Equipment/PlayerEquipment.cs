using System;
using _Project.Source.Inventory.Item.ItemTypes;
using UnityEngine;

namespace _Project.Source.Player
{
    public class PlayerEquipment : MonoBehaviour
    {
        private Weapon _equippedWeapon;
        
        [SerializeField] private ItemUsageHandler _itemUsageHandler;
        
        public event Action<Weapon> OnWeaponEquipped;
        public event Action OnWeaponUnequipped;

        private void OnEnable()
        {
            _itemUsageHandler.OnWeaponItemUsed += EquipWeapon;
        }

        private void OnDisable()
        {
            _itemUsageHandler.OnWeaponItemUsed -= EquipWeapon;
        }

        private void EquipWeapon(Weapon weapon)
        {
            if (_equippedWeapon == weapon)
            {
                UnequipWeapon();
                return;
            }

            _equippedWeapon = weapon;
            OnWeaponEquipped?.Invoke(weapon);
        }

        private void UnequipWeapon()
        {
            if (_equippedWeapon == null) return;
            
            _equippedWeapon = null;
            OnWeaponUnequipped?.Invoke();
        }
    }
}