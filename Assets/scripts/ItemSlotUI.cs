
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Items
{
    public abstract  class ItemSlotUI:MonoBehaviour, IDropHandler
    {
        [SerializeField] protected Image itemIconImage = null;
        public int slotIndex { get; private set; }

        public abstract HotbarItem SlotItem { get; set; }

        private void OnEnable()
        {
            UpdateSlotUI();
        }

        protected void Start()
        {
            slotIndex = transform.GetSiblingIndex();
            UpdateSlotUI();
        }

        public abstract void OnDrop(PointerEventData eventData);
        public abstract void UpdateSlotUI();

        protected virtual void EnableSlotUI(bool Enable)
        {
            itemIconImage.enabled = Enable;
        }
    }
}