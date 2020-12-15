using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Items
{[RequireComponent(typeof(CanvasGroup))]
    public class ItemDragHandler:MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerExitHandler,IPointerEnterHandler
    {
        [SerializeField] protected ItemSlotUI itemSlotUI = null;
        private CanvasGroup _canvasGroup = null;
        private Transform originalParent = null;
        private bool isHovering = false;
        public ItemSlotUI ItemSlotUI => itemSlotUI;

        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            
        }

        private void OnDisable()
        {
            if (isHovering)
            {
                isHovering = false;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                originalParent = transform.parent;
                transform.SetParent(transform.parent.parent);
                _canvasGroup.blocksRaycasts = false;
            }
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                transform.position = Input.mousePosition;
                
            }
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                transform.SetParent(originalParent);
                transform.localPosition = Vector3.zero;
                _canvasGroup.blocksRaycasts = true;
                

            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isHovering = false; 
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            isHovering = true;
        }
    }
}