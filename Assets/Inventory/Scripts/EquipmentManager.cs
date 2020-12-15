using System;
using System.Collections;
using System.Collections.Generic;
using Inventory.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton

    public static EquipmentManager instance;
    private Inventory.Scripts.Inventory inventory;
    
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    #endregion
    private Equipment[] currentEquipment;
    private SkinnedMeshRenderer[] currentMeshes;
    public SkinnedMeshRenderer targerMesh;
    private void Start()
    {
       int numSlots =  System.Enum.GetNames(typeof(EqipmentSlot)).Length;
       currentEquipment = new Equipment[numSlots];
       inventory = Inventory.Scripts.Inventory.instance;
       currentMeshes = new SkinnedMeshRenderer[numSlots];

    }

    public void Equip(Equipment newItem)
    {
        CurrentInventoryUI.instance.AddItem(newItem);
        //gets at which index of newItem in the EqupmentEnum
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem,oldItem);
        }
        currentEquipment[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targerMesh.transform;
        newMesh.bones = targerMesh.GetComponentInParent<SkinnedMeshRenderer>().bones;
        newMesh.rootBone = targerMesh.GetComponentInParent<SkinnedMeshRenderer>().rootBone;
        currentMeshes[slotIndex] = newMesh;
        newMesh.transform.position = targerMesh.transform.position;
        newMesh.transform.rotation = targerMesh.transform.rotation;
        newMesh.transform.localScale = targerMesh.transform.localScale;
        //newMesh.transform.localScale = targerMesh.bounds.extents;
        //CurrentInventory'e ekle
    }

    public void UnEquipped(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            if (currentMeshes != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject); 
            }
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
            currentEquipment[slotIndex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null,oldItem);
            }
        }
    }
    
    public void UnEquippedAll()
    {
        
            for (int i = 0; i < currentEquipment.Length; i++)
            {
                UnEquipped(i);
            }
        }
    
}
