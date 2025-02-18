using UnityEngine;

namespace _Project.Source.Player
{
    public class PlayerCharacterFactory : MonoBehaviour
    {
        [SerializeField] private FirstPersonMovement characterPrefab;
        [SerializeField] private Transform characterSpawnPoint;
        
        public PlayerCharacter Create()
        {
            return Instantiate(characterPrefab, characterSpawnPoint)
                .GetComponent<PlayerCharacter>();
        }
    }
}