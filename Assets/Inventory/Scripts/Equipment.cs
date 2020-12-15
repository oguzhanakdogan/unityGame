using System.Collections;
using System.Collections.Generic;
using Inventory.Scripts;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public SkinnedMeshRenderer mesh;
    public EqipmentSlot  equipSlot;
    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        //Equip the item
        EquipmentManager.instance.Equip(this);
        //Remove it from inventory
        RemoveFromInventory();
    }

}

 public enum EqipmentSlot{Head, Chest, earning, Weapon, Shield, Feet}