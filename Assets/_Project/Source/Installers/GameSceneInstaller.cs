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
            // Биндим фабрику игрока
            Container.Bind<IFactory<FirstPersonMovement>>()
                .To<PlayerCharacterFactory>()
                .AsSingle()
                .WithArguments(characterPrefab, characterSpawnPoint, Container);

            // Биндим фабрику ItemUsageHandler
            Container.Bind<IFactory<ItemUsageHandler>>()
                .To<ItemUsageHandlerFactory>()
                .AsSingle();

            // Биндим Hotbar
            Container.Bind<Hotbar>().FromInstance(_hotbar).AsSingle();
        }
    }
}