using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Scripts
{
    public class CurrentItems : MonoBehaviour
    {
        private List<Item> items = new List<Item>();

        #region Singleton

        public static CurrentItems currentItemsInstance;

        private void Awake()
        {
            if (currentItemsInstance != null)
            {
                Debug.Log("an CurrentItemInstance is available..");
                return;
            }

            currentItemsInstance = this;
        }

        #endregion
        
        public bool Add(Item item)
        {
            if (!item.isDefaultItem)
            {
               
               
            }

            return true;
        }


    }
}