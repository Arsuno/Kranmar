using System;
using _Project.Source.Inventory.Item.ItemTypes;
using UnityEngine;

namespace _Project.Source.Player
{
    public class PlayerEquipment : MonoBehaviour
    {
        public event Action<Weapon> OnWeaponEquippedEv;
        public event Action OnWeaponUnequippedEv;
        
        private Weapon _equippedWeapon;
        
        [SerializeField] private ItemUsageHandler _itemUsageHandler;

        private void OnEnable()
        {
            _itemUsageHandler.OnWeaponItemUsedEv += EquipWeapon;
        }

        private void OnDisable()
        {
            _itemUsageHandler.OnWeaponItemUsedEv -= EquipWeapon;
        }

        private void EquipWeapon(Weapon weapon)
        {
            if (_equippedWeapon == weapon)
            {
                UnequipWeapon();
                return;
            }

            _equippedWeapon = weapon;
            OnWeaponEquippedEv?.Invoke(weapon);
        }

        private void UnequipWeapon()
        {
            if (_equippedWeapon == null) return;
            
            _equippedWeapon = null;
            OnWeaponUnequippedEv?.Invoke();
        }
    }
}