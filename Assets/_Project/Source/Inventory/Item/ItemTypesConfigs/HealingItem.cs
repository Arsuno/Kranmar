using UnityEngine;

namespace _Project.Source.Inventory.Item.ItemTypesConfigs
{
    [CreateAssetMenu(menuName = "Configs/Items/New Healing Item")]
    public class HealingItem : HotBarItem
    {
        public int HealingAmount;
    }
}