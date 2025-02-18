using System.Collections.Generic;
using UnityEngine;
using _Project.Source.Inventory;

namespace _Project.Source.UI
{
    public class HotBarView : MonoBehaviour
    {
        [SerializeField] private Hotbar _hotbar;
        
        [SerializeField] private Transform _slotsParent;
        [SerializeField] private GameObject _slotPrefab;
        
        private readonly List<SlotView> _spawnedSlots = new();
        
        private void OnEnable()
        {
            _hotbar.OnHotbarChangedEv += Refresh;
        }

        private void OnDisable()
        {
            _hotbar.OnHotbarChangedEv -= Refresh;
        }
        
        private void Refresh(List<HotbarSlot> slots)
        {
            ClearSlots();
            AddSlots(slots);
        }

        private void AddSlots(List<HotbarSlot> slots)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                SlotView slot = Instantiate(_slotPrefab, _slotsParent).GetComponent<SlotView>();
                _spawnedSlots.Add(slot);

                if (slots[i].Item != null)
                {
                    slot.SetIcon(slots[i].Item.Icon);
                    slot.SetAmountTextValue(slots[i].ItemAmount);    
                }
            }
        }

        private void ClearSlots()
        {
            Debug.Log(_spawnedSlots.Count);
            
            foreach (var slot in _spawnedSlots)
                Destroy(slot.gameObject);
            
            _spawnedSlots.Clear();
        }
    }
}