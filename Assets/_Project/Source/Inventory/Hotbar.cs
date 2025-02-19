using System;
using System.Collections.Generic;
using _Project.Source.Inventory.Configs;
using _Project.Source.Inventory.Item;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Source.Inventory
{
    public class Hotbar : MonoBehaviour
    {
        [SerializeField] private HotbarConfig _config;
        
        private List<HotbarSlot> _slots;
        private int _slotCount;
        
        public event Action<List<HotbarSlot>> OnHotbarChanged;
        public event Action<HotBarItem> OnItemUsed;
    
        private void Start()
        {
            _slots = new List<HotbarSlot>();
            _slotCount = _config.SlotsAmount;
            
            for (int i = 0; i < _slotCount; i++)
            {
                _slots.Add(new HotbarSlot());

                if (i < _config.StartItems.Length)
                    _slots[i].AssignItem(_config.StartItems[i]);
            }
            
            OnHotbarChanged?.Invoke(_slots);
        }
    
        private void Update()
        {
            for (int i = 0; i < _slotCount; i++)
            {
                Key key = (Key)((int)Key.Digit1 + i);
                
                if (Keyboard.current[key].wasPressedThisFrame)
                    SelectSlot(i);
            }
        }
        
        public void AddItem(HotBarItem item, int amount)
        {
            foreach (var slot in _slots)
            {
                if (slot.Item == item)
                {
                    slot.AddItemAmount(amount);
                    OnHotbarChanged?.Invoke(_slots);
                    
                    return;
                }
            }
            
            foreach (var slot in _slots)
            {
                if (slot.Item == null)
                {
                    slot.AssignItem(item);
                    OnHotbarChanged?.Invoke(_slots);
                    
                    return;
                }
            }

            Debug.Log("Hotbar is full!");
        }

        public void RemoveItem(HotBarItem item, int amount)
        {
            foreach (var slot in _slots)
            {
                if (slot.Item == item)
                {
                    slot.RemoveItemAmount(amount);
                    OnHotbarChanged?.Invoke(_slots);
                    
                    return;
                }
            }
        }
    
        private void SelectSlot(int index)
        {
            if (index < 0 || index >= _slotCount) return;
            
            if (_slots[index].Item != null)
                OnItemUsed?.Invoke(_slots[index].Item);
        }
    }
}