using _Project.Source.Player;
using UnityEngine;

namespace _Project.Source.Inventory.Item.ItemTypes
{
    [CreateAssetMenu(menuName = "Configs/Items/New Weapon")]
    public class Weapon : HotBarItem, IUsable
    {
        public int AmmoCapacity;
        public int Damage;
        public float ReloadSpeed;
        public GameObject Prefab;
        public GameObject ProjectilePrefab;
        
        public void Use(PlayerCharacter player)
        {
            player.ItemUsageHandler.UseWeapon(this);
        }
    }
}