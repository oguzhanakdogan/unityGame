using UnityEngine;

namespace Inventory.Scripts
{
    public class ItemPickUp : Interactible
    {
        
        public Item item;
        public override void Interact()
        {
            base.Interact();
            PickUp();
        }

        private void  PickUp()
        {
            
            Debug.Log("Picking up" + item.name);
          bool pickedup  =  Inventory.instance.Add(item) ; 
            //Add to inventory
            if (pickedup)
            {
                Destroy(gameObject);
            }
        }
    }
}