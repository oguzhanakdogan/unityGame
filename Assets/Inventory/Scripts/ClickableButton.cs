using System;
using Game.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory.Scripts
{
    public class ClickableButton : MonoBehaviour,IPointerClickHandler
    {
        public CurrentInventorySlot slot;
        private void Start()
        {
            
        }

        public void OnPointerClick(PointerEventData eventData)
        {

            if (eventData.button == PointerEventData.InputButton.Right)
            {
                
                slot.ClearSlot();
                
            }else if (eventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("Left clicking");   
            }
        }
    }
}