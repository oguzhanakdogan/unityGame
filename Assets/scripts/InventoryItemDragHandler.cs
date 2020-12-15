using UnityEngine.EventSystems;

namespace Game.Items
{
    public class InventoryItemDragHandler: ItemDragHandler
    {
        //drag inventor
        public override void OnPointerUp(PointerEventData pointerEventData)
        {
            if (pointerEventData.button == PointerEventData.InputButton.Left)
            {
                base.OnPointerUp(pointerEventData);
                if (pointerEventData.hovered.Count == 0)
                {
                    //destroyITem or drop Item
                }
            }
            
            
        }
    }
}