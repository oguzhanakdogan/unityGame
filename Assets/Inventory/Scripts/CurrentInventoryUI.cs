using System;
using UnityEngine;

namespace Inventory.Scripts
{
    public class CurrentInventoryUI : MonoBehaviour
    {
        public CurrentInventorySlot head = new CurrentInventorySlot();
        public CurrentInventorySlot armor = new CurrentInventorySlot();
        public CurrentInventorySlot shield =  new CurrentInventorySlot();
        public CurrentInventorySlot earning= new CurrentInventorySlot();
        public CurrentInventorySlot shoes = new CurrentInventorySlot();
        public CurrentInventorySlot weapon = new CurrentInventorySlot();

        #region Singleton

        public static CurrentInventoryUI instance;

        private void Awake()
        {
            if (instance != null) return;
            instance = this;
        }

        #endregion
        public void AddItem(Equipment item)
        {
            //if(item.)
            if (item.equipSlot == EqipmentSlot.Head)
            {
                if (head.getItem() != null)
                {
                    head.ClearSlot();
                }
                head.AddItem(item,(int) EqipmentSlot.Head);
            } else if (item.equipSlot == EqipmentSlot.Chest)
            {
                if (armor.getItem() != null)
                {
                    armor.ClearSlot();
                }
                armor.AddItem(item,(int) EqipmentSlot.Chest);
            }
            else  if (item.equipSlot == EqipmentSlot.Shield)
            {
                if (shield.getItem() != null)
                {
                    shield.ClearSlot();
                }
                shield.AddItem(item,(int) EqipmentSlot.Shield);
            }else if (item.equipSlot == EqipmentSlot.Feet)
            {
                if (shoes.getItem() != null)
                {
                    shoes.ClearSlot();
                } 
                shoes.AddItem(item,(int) EqipmentSlot.Feet);   
            }else if (item.equipSlot == EqipmentSlot.Weapon)
            {
                if (weapon.getItem() != null)
                {
                    weapon.ClearSlot();
                } 
                weapon.AddItem(item, (int) EqipmentSlot.Weapon);
            }else if (item.equipSlot == EqipmentSlot.earning)
            {
                if (earning.getItem() != null)
                {
                    earning.ClearSlot();
                } 
                earning.AddItem(item,(int) EqipmentSlot.earning);
            }
            
            
            
        }

        public void deleteItem(Equipment equipment)
        {
            if (equipment.equipSlot == EqipmentSlot.Head)
            {
                head = null;
            }
           else if (equipment.equipSlot == EqipmentSlot.Chest)
            {
                armor = null;
            }else  if (equipment.equipSlot == EqipmentSlot.Shield)
            {
                shield = null;
            }else if (equipment.equipSlot == EqipmentSlot.Feet)
            {
                shoes = null;
            }else if (equipment.equipSlot == EqipmentSlot.Weapon)
            {
                weapon = null;
            }else if (equipment.equipSlot == EqipmentSlot.earning)
            {
                earning = null;
            }
        }
        
    }
}