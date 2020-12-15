using System;

namespace Game.Items
{
    public class ItemContainer : IItemContainer
    {
       
        private ItemSlot[] ItemSlots = new ItemSlot[0];
        
        
        public Action onItemsUpdate = delegate {  };
        public ItemSlot GetSlotByIndex(int index) => ItemSlots[index];

        public ItemContainer(int size) => ItemSlots = new ItemSlot[size];
        
        
        public ItemSlot AddItem(ItemSlot itemSlot)
        {
            for (int i = 0; i < ItemSlots.Length; i++)
            {
                if (ItemSlots[i].item != null)
                {
                    if (ItemSlots[i].item == itemSlot.item)
                    {
                        int slotRemainingSpace = ItemSlots[i].item.MaxStack - ItemSlots[i].quantity;
                        if (itemSlot.quantity <= slotRemainingSpace)
                        {
                            ItemSlots[i].quantity += itemSlot.quantity;
                            itemSlot.quantity = 0;
                            //invoke 
                            onItemsUpdate.Invoke();     
                            return itemSlot;
                        }
                        else if (slotRemainingSpace > 0)
                        {
                            ItemSlots[i].quantity += slotRemainingSpace;
                            itemSlot.quantity -= slotRemainingSpace;
                        }
                        
                    }
                }
            }

            for (int i = 0; i < ItemSlots.Length; i++)
            {
                if (ItemSlots[i].item == null)
                {
                    if (itemSlot.quantity <= itemSlot.item.MaxStack)
                    {
                        ItemSlots[i] = itemSlot;
                        itemSlot.quantity = 0;
                        
                        onItemsUpdate.Invoke(); 

                        return itemSlot;
                    }
                    else
                    {
                        ItemSlots[i] = new ItemSlot(itemSlot.item,itemSlot.quantity);
                        itemSlot.quantity -= itemSlot.item.MaxStack;
                    }
                }
            }
            onItemsUpdate.Invoke(); 

            return itemSlot;
        }

        public void RemoveItem(ItemSlot itemSlot)
        {
            for (int i = 0; i < ItemSlots.Length; i++)
            {
                if (ItemSlots[i].item != null)
                {
                    if (ItemSlots[i].item == itemSlot.item)
                    {
                        if (ItemSlots[i].quantity < itemSlot.quantity)
                        {
                            itemSlot.quantity -= ItemSlots[i].quantity;
                            ItemSlots[i] = new ItemSlot();
                            
                        }
                        else
                        {
                            ItemSlots[i].quantity -= itemSlot.quantity;
                            if (ItemSlots[i].quantity == 0)
                            {
                                ItemSlots[i] = new ItemSlot();
                                onItemsUpdate.Invoke(); 

                                return;
                            }
                        }
                    }
                }
            }
        }


        public void RemoveAt(int slotIndex)
        {
            if (slotIndex < 0 || slotIndex > ItemSlots.Length - 1)
            {
                
                return;
            }
            ItemSlots[slotIndex] = new ItemSlot();
            onItemsUpdate.Invoke(); 

        }

        
        public void swap(int index1, int index2)
        {

            ItemSlot firstSlot = ItemSlots[index1];
            ItemSlot secondSlot = ItemSlots[index2];
            if (firstSlot == secondSlot) { return; }
            if(secondSlot.item != null){
                if (firstSlot.item == secondSlot.item)
                {
                    int secondSlotRemaningSpace = secondSlot.item.MaxStack - secondSlot.quantity;
                    if (firstSlot.quantity <= secondSlotRemaningSpace)
                    {
                        ItemSlots[index2].quantity += firstSlot.quantity;
                        ItemSlots[index1] = new ItemSlot();
                        onItemsUpdate.Invoke(); 
                        return;
                    }
                }
                
            }

            ItemSlots[index1] = secondSlot;
            ItemSlots[index2] = firstSlot;
            onItemsUpdate.Invoke(); 

        }

        public bool HasItem(InventoryItem item)
        {
            foreach (ItemSlot itemSlot in ItemSlots)
            {
                if(itemSlot.item == null){continue;}
                if(itemSlot.item != item) { continue; }

                return true;
            }
            return false;

        }

        public int GetItemQuantity(InventoryItem item)
        {
            int totalCount = 0;
            foreach (ItemSlot itemSlot in ItemSlots)
            {
                if(itemSlot.item == null) { continue; }
                if(itemSlot.item != item) { continue; }

                totalCount += itemSlot.quantity;

            }
            return totalCount;
        }
    }
}