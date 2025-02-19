using _Project.Source.Inventory;
using _Project.Source.PickupObjects;
using UnityEngine;
using Zenject;

namespace _Project.Source.Player
{
    public class PlayerCharacter : MonoBehaviour, IItemCollector
    {
        [SerializeField] private Health _health;
        [SerializeField] private PlayerEquipment _equipment;
        [SerializeField] private ItemUsageHandler _itemUsageHandler;
        
        public Health Health => _health;
        public Hotbar Hotbar { get; private set; }
        public ItemUsageHandler ItemUsageHandler => _itemUsageHandler;

        [Inject]
        private void Construct(Hotbar hotbar)
        {
            Hotbar = hotbar;
        }

        public void CollectItem(PickupObject pickupObject)
        {
            pickupObject.Interact(this);
        }
    }
}