using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory.Scripts.Inventory Inventory;
    public Transform itemsParent;
    public Inventory_Slot[] _slots;
    public GameObject inventoryUI;
    private void Start()
    {
        Inventory = global::Inventory.Scripts.Inventory.instance;

        Inventory.OnItemChangedCallBack += UpdateUI;
        _slots = itemsParent.GetComponentsInChildren<Inventory_Slot>();

    }

   

    private void Update()
    {
        
       
       
        
    }

    void UpdateUI()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (i < Inventory.items.Count)
            {
                _slots[i].AddItem(Inventory.items[i]);
            }
            else
            {
                _slots[i].ClearSlot();
            }
        }
    }


}

