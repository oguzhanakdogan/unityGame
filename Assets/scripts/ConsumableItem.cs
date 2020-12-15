using System.Text;
using UnityEngine;

namespace Game.Items
{
    public class ConsumableItem : InventoryItem
    {
        [Header("Consumable Data")] [SerializeField]
        private string useText = "Does smt maybe?";
        public override string GetInfoDisplayText()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(name).AppendLine();
            builder.Append("<color = green>Use: ").Append(useText).Append("<color>").AppendLine();
            builder.Append("Max stack: ").Append(MaxStack).AppendLine();
            builder.Append("Sell price: ").Append(SellPrice).Append(" Gold");
            return builder.ToString();
        }
    }
}