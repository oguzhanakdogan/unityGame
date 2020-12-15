using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory.Scripts
{
    public class ClickableInventoryButton: MonoBehaviour,IPointerClickHandler
    {
    public Inventory_Slot slot;
    
    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (ChangeItemMaganer.slot != null)
            {
                ChangeItemMaganer.slot.makeNonTransparent();
                ChangeItemMaganer.slot = null; 
                ChangeItemMaganer.moving = false;
                Debug.Log("çalışıyor");
            }

            slot.UseItem();

        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log(transform.gameObject.name + " çalışıyor");
            if (ChangeItemMaganer.moving)
            {
                ChangeItemMaganer.PutControl(slot);
            }
            else
            {
                Debug.Log("denem123425");
                ChangeItemMaganer.TakeControl(slot);
            }
                
            

        }
        
    }
    }
}