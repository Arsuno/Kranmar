using _Project.Source.Inventory;
using _Project.Source.PickupObjects;
using UnityEngine;
using Zenject;

namespace _Project.Source.Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private PlayerEquipment _equipment;
        
        public Health Health => _health;
        public Hotbar Hotbar { get; private set; }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out PickupObject pickupObject))
                pickupObject.Interact(this);
        }

        [Inject]
        private void Construct(Hotbar hotbar)
        {
            Hotbar = hotbar;
        }
    }
}