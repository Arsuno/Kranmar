using _Project.Source.PickupObjects;
using _Project.Source.Player;
using UnityEngine;
using Zenject;

namespace _Project.Source
{
    public class ItemPickupHandler : MonoBehaviour
    {
        private IItemCollector _itemCollector;
        
        /*[Inject]
        private void Construct(IItemCollector itemCollector)
        {
            _itemCollector = itemCollector;
        }*/

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out PickupObject pickupObject))
                TryPickup(pickupObject);
        }
        
        private void TryPickup(PickupObject pickupObject)
        {
            pickupObject.Interact(_itemCollector);
        }
    }
}