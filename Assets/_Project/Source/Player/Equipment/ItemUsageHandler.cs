using System;
using _Project.Source.Inventory;
using _Project.Source.Inventory.Item;
using _Project.Source.Inventory.Item.ItemTypes;
using _Project.Source.Inventory.Item.ItemTypesConfigs;
using UnityEngine;
using Zenject;

namespace _Project.Source.Player
{
    public class ItemUsageHandler : MonoBehaviour
    {
        public event Action<Weapon> OnWeaponItemUsedEv; 
        
        [SerializeField] private PlayerCharacter _playerCharacter;

        private Hotbar _hotbar;
        
        private void OnDisable()
        {
            _hotbar.OnItemUsedEv -= OnItemUsed;
        }
        
        [Inject]
        public void Construct(Hotbar hotbar)
        {
            _hotbar = hotbar;
            
            _hotbar.OnItemUsedEv += OnItemUsed;
        }
        
        private void OnItemUsed(HotBarItem item)
        {
            if (item is Weapon weapon)
                OnWeaponItemUsedEv?.Invoke(weapon);

            if (item is HealingItem healingItem)
            {
                _hotbar.RemoveItem(healingItem, 1);
                _playerCharacter.Health.Heal(healingItem.HealingAmount);
            }
        }
    }
}