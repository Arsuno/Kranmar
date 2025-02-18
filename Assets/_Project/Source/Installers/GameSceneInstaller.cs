using _Project.Source.Inventory;
using UnityEngine;
using Zenject;

namespace _Project.Source.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private Hotbar _hotbar;
        
        public override void InstallBindings()
        {
            Container.Bind<Hotbar>().FromInstance(_hotbar).AsSingle();
        }
    }
}