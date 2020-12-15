using System;
using UnityEngine;

namespace Inventory.Scripts
{
    public class InventoryActivity : MonoBehaviour
    {
        public GameObject inventoryUI;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf); 
            }
        }
    }
}