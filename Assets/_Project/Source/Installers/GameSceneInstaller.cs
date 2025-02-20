using _Project.Source.Inventory;
using _Project.Source.Player;
using UnityEngine;
using Zenject;

namespace _Project.Source.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private FirstPersonMovement characterPrefab;
        [SerializeField] private Transform characterSpawnPoint;
        [SerializeField] private Hotbar _hotbar;
        
        public override void InstallBindings()
        {
            // Биндим Hotbar
            Container.Bind<Hotbar>().FromInstance(_hotbar).AsSingle().NonLazy();
            
            // Создаём экземпляр игрока
            var playerInstance = Container.InstantiatePrefabForComponent<FirstPersonMovement>(
                characterPrefab, characterSpawnPoint.position, characterSpawnPoint.rotation, null);

            // Биндим FirstPersonMovement
            Container.Bind<FirstPersonMovement>().FromInstance(playerInstance).AsSingle();

            // Биндим ItemUsageHandler
            Container.Bind<ItemUsageHandler>().FromInstance(playerInstance.GetComponent<ItemUsageHandler>()).AsSingle();
            
            // Биндим IItemCollector (если FirstPersonMovement — это PlayerCharacter)
            var playerCharacter = playerInstance.GetComponent<PlayerCharacter>();
            Container.Bind<IItemCollector>().To<PlayerCharacter>().FromInstance(playerCharacter).AsSingle();
            
            var itemPickupHandler = playerInstance.GetComponent<ItemPickupHandler>();
            Container.Inject(itemPickupHandler);
        }
    }
}