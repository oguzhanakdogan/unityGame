using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Scripts
{
    public class Inventory : MonoBehaviour
    {
        #region Singleton

        

        public static Inventory instance;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.Log("More than one Instance of inventory found");
                return;
            }
            instance = this;

        }
        #endregion

        public delegate void OnItemChanged();

        public OnItemChanged OnItemChangedCallBack;
        public int space = 20;
        public List<Item> items = new List<Item>();

        public bool Add(Item item)
        {
            if (!item.isDefaultItem)
            {
                if(items.Count >= space)
                {
                    Debug.Log("not enough room!");
                    return false;
                }

                
                items.Add(item);
               // Debug.Log("Adding is succesfully");
                if (OnItemChangedCallBack != null)
                {
                   // Debug.Log("Adding is succesfully 1");

                    OnItemChangedCallBack.Invoke();
                }
            }

            return true;
        }

        public void Remove(Item item)
        {
            items.Remove(item);
            if (OnItemChangedCallBack != null)
            {
                OnItemChangedCallBack.Invoke();
            }

        }

        
    }
}