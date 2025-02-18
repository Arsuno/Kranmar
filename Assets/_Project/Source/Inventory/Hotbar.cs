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
        public event Action<List<HotbarSlot>> OnHotbarChangedEv;
        public event Action<HotBarItem> OnItemUsedEv;

        [SerializeField] private HotbarConfig _config;
        private List<HotbarSlot> _slots;

        private int _slotCount;
    
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
            
            OnHotbarChangedEv?.Invoke(_slots);
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
                    OnHotbarChangedEv?.Invoke(_slots);
                    
                    return;
                }
            }
            
            foreach (var slot in _slots)
            {
                if (slot.Item == null)
                {
                    slot.AssignItem(item);
                    slot.AddItemAmount(amount);
                    OnHotbarChangedEv?.Invoke(_slots);
                    
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
                    OnHotbarChangedEv?.Invoke(_slots);
                    
                    return;
                }
            }
        }
    
        private void SelectSlot(int index)
        {
            if (index < 0 || index >= _slotCount) return;
            
            if (_slots[index].Item != null)
                OnItemUsedEv?.Invoke(_slots[index].Item);
        }
    }
}