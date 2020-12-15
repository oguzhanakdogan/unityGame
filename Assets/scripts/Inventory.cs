using System;
using UnityEngine;


namespace Game.Items
{
    public class Inventory:ScriptableObject
    {
        public ItemContainer itemContainer { get; } = new ItemContainer(20);

        public void OnEnable()
        {
            
        }

        public void OnDisable()
        {
            
        }
    }
}