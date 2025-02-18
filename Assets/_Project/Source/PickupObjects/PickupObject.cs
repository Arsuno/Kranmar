using System.Collections;
using _Project.Source.Inventory.Item;
using _Project.Source.Player;
using UnityEngine;

namespace _Project.Source.PickupObjects
{
    public class PickupObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private HotBarItem item;
        [SerializeField] private GameObject _interactableObject;
        [SerializeField] private float _respawnTime;
        
        public void Interact(PlayerCharacter player)
        {
            player.Hotbar.AddItem(item, 1);
            _interactableObject.SetActive(false);
            StartCoroutine(WaitForRespawn());
        }

        private IEnumerator WaitForRespawn()
        {
            yield return new WaitForSeconds(_respawnTime);
            _interactableObject.SetActive(true);
        }
    }
}