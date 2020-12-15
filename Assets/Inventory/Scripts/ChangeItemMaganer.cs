using UnityEngine;

namespace Inventory.Scripts
{
    public static class ChangeItemMaganer
    {
        public static Inventory_Slot slot;
        public static bool moving = false;
        public static bool PutControl(Inventory_Slot slot1)
        {
            
            if (slot != null)
            {
                Debug.Log("şu anda yerleştiriyorsun");
                if (slot1.getItem() != null)
                {
                    Debug.Log("burası dolu kardeşim");
                    return false;
                }
                Debug.Log("koyuyorsun");
                slot.makeNonTransparent();
                slot1.AddItem(slot.getItem());
                slot.ClearSlot();
                slot = null;
                moving = false;
                return true;

            }
          
           

            return false;
        }

        public static bool TakeControl(Inventory_Slot slot1)
        {
            if (slot == null )
            {
                Debug.Log("elimizde eleman yok alıyorsun...");

                if (slot1.getItem() == null)
                {
                    Debug.Log("elimizde eleman yok alıyorsun... ama burası boş");
                    return false;
                }
                Debug.Log("elimizde eleman yok alıyorsun... ve aldın");
                slot = slot1;
                moving = true;
                slot.makeTransparent();
                return true;
                
            }
            return false;
        }


    }
}