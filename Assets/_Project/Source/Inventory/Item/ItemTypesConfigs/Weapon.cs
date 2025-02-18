using UnityEngine;

namespace _Project.Source.Inventory.Item.ItemTypes
{
    [CreateAssetMenu(menuName = "Configs/Items/New Weapon")]
    public class Weapon : HotBarItem
    {
        public int AmmoCapacity;
        public int Damage;
        public float FireRate;
        public float ReloadSpeed;
        public GameObject Prefab;
    }
}