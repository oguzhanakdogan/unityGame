using UnityEngine;

namespace Game.Items
{
    //store all of functions that anything that contains items needs to have
    public interface IItemContainer
    {
        ItemSlot AddItem(ItemSlot itemSlot);
        void RemoveItem(ItemSlot itemSlot);
        void RemoveAt(int slotIndex);
        void swap(int index1, int index2);
         bool HasItem(InventoryItem item);
         int GetItemQuantity(InventoryItem item);
    }
}