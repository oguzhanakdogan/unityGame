using System;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory.Scripts
{
    public class CurrentInventorySlot : MonoBehaviour
    {
        protected Item item;
        public Image icon;
        public int slotIndex;
        private Inventory instance;
        private void Start()
        {
            instance = Inventory.instance;
        }

        public void AddItem(Item newItem, int slotIndex)
        {
            this.slotIndex = slotIndex;
            item = newItem;
            icon.sprite = newItem.icon;
            icon.enabled = true;
        }

        public void ClearSlot()
        {
            if (item == null) return;
            item = null;
            icon.sprite = null;
            icon.enabled = false; 
            
            EquipmentManager.instance.UnEquipped(slotIndex);
        }

        public Item getItem()
        {
            return item;
        }
    
        public void UseItem()
        {
            if (item != null)
            {
                item.Use();
            }
        }
        
    }
}