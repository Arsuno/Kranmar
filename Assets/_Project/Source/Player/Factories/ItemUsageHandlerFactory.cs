using Zenject;

namespace _Project.Source.Player
{
    public class ItemUsageHandlerFactory : IFactory<ItemUsageHandler>
    {
        private readonly IFactory<FirstPersonMovement> _playerFactory;

        public ItemUsageHandlerFactory(IFactory<FirstPersonMovement> playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public ItemUsageHandler Create()
        {
            var player = _playerFactory.Create();
            return player.GetComponent<ItemUsageHandler>();
        }
    }
}