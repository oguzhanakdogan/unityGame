using UnityEngine;

namespace Game.Items
{
    public abstract class InventoryItem : HotbarItem
    {
        
        [Header("Item data")] [SerializeField][Min(0)] private int sellPrice = 1;
        [Min(1)]private int maxStack;


        public int SellPrice => sellPrice;

        public int MaxStack => maxStack;
        
        public override string ColouredName
        {
            get
            {
                return name;
            }
        }

        
    }
}