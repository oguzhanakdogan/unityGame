using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Items
{
    public class InventorySlot :ItemSlotUI, IDropHandler
    {
        [SerializeField] private Inventory inventory = null;
        [SerializeField] private TextMeshProUGUI itemQuantityText = null;

        public ItemSlot itemSlot => inventory.itemContainer.GetSlotByIndex(slotIndex);
        public override HotbarItem SlotItem
        {
            get
            {
                return itemSlot.item;
            }
            set{}
            
        }
        

        public override void OnDrop(PointerEventData eventData)
        {
            ItemDragHandler itemDragHander = eventData.pointerDrag.GetComponent<ItemDragHandler>();
            if (itemDragHander == null)
            { return; }

            if ((itemDragHander.ItemSlotUI as InventorySlot) != null)
            { 
                inventory.itemContainer.swap(itemDragHander.ItemSlotUI.slotIndex, slotIndex);
            }
        }

        public override void UpdateSlotUI()
        {
            if (itemSlot.item == null)
            {
                EnableSlotUI(false);
                return;
            }
            EnableSlotUI(true);
            itemIconImage.sprite = itemSlot.item.Icon;
            itemQuantityText.text = itemSlot.quantity > 1 ? itemSlot.quantity.ToString() : "" ;
            
        }

        protected override void EnableSlotUI(bool Enable)
        {
            base.EnableSlotUI(Enable);
            itemQuantityText.enabled = enabled;
        }
    }
}