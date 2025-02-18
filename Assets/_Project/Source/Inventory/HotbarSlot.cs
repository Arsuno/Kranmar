using _Project.Source.Inventory.Item;
using _Project.Source.Inventory.Item.ItemTypes;

namespace _Project.Source.Inventory
{
    public class HotbarSlot
    {
        public HotBarItem Item { get; private set; }
        public int ItemAmount { get; private set; }
    
        public void AssignItem(HotBarItem item)
        {
            Item = item;
        }

        public void AddItemAmount(int amount)
        {
            if (Item == null && (Item is Weapon weapon))
                return;

            if (ItemAmount < Item.StackAmount)
                ItemAmount += amount;
        }

        public void RemoveItemAmount(int amount)
        {
            if (Item == null && (Item is Weapon weapon))
                return;

            if (ItemAmount >= amount)
            {
                ItemAmount -= amount;

                if (ItemAmount <= 0)
                {
                    Item = null;
                    ItemAmount = 0;
                }
            }
        }
        
    }
}