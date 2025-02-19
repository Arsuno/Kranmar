using System;
using _Project.Source.Inventory;
using _Project.Source.Inventory.Item;
using _Project.Source.Inventory.Item.ItemTypes;
using UnityEngine;
using Zenject;

namespace _Project.Source.Player
{
    public class ItemUsageHandler : MonoBehaviour
    {
        private Hotbar _hotbar;
        
        [SerializeField] private PlayerCharacter _playerCharacter;
        
        public event Action<Weapon> OnWeaponItemUsed; 

        private void Awake()
        {
            if (_hotbar != null)
                _hotbar.OnItemUsed += OnItemUsed;
        }

        private void OnDestroy()
        {
            if (_hotbar != null)
                _hotbar.OnItemUsed -= OnItemUsed;
        }

        [Inject]
        public void Construct(Hotbar hotbar)
        {
            _hotbar = hotbar;
        }
        
        public void UseWeapon(Weapon weapon)
        {
            OnWeaponItemUsed?.Invoke(weapon);
        }
    
        private void OnItemUsed(HotBarItem item)
        {
            if (item is IUsable usableItem)
            {
                Debug.Log("Player character " + _playerCharacter);
                usableItem.Use(_playerCharacter);
            }
        }
    }
}