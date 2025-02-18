using _Project.Source.Inventory;
using _Project.Source.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Source
{
    public class EntryPoint : MonoBehaviour
    {
        [FormerlySerializedAs("playerFactory")] [SerializeField] private PlayerCharacterFactory playerCharacterFactory;
        [SerializeField] private Hotbar _hotbar;
        
        private void Awake()
        {
            var player = playerCharacterFactory.Create();
            player.Initialize(_hotbar);    
        }
    }
}