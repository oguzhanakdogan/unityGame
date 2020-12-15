using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ItemToolTip : MonoBehaviour
{

    [SerializeField] private Text itemNameText;
    [SerializeField] private Text itemSlotText;
    [SerializeField] private Text itemStatsText;

    #region Singleton

    public static ItemToolTip ToolTip;
    

    #endregion
    

    private void Awake()
    {
        if (ToolTip != null) return;
        ToolTip = this;
    }

    private void Start()
    {
        ToolTip = this;
        HideToolTip();

    }

    private StringBuilder _builder = new StringBuilder();
    public void ShowToolTip(Equipment item)
    {
        if (item == null) {HideToolTip();return;}
        itemNameText.text = item.name;
        itemSlotText.text = item.equipSlot.ToString();
        _builder.Length = 0;
        AddStat(item.armorModifier, "Savunma ");

        itemStatsText.text = _builder.ToString();
        gameObject.SetActive(true);
        
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }

    private void AddStat(float value, string statName)
    {
        if (value != 0)
        {
            if (_builder.Length > 0)
            {
                _builder.AppendLine();
            }
            if (value > 0)
            {
                _builder.Append(statName + " +");
            }
            else
            {
                _builder.Append(statName + " -");

            }
            
            _builder.Append(" ");
            _builder.Append(value);
        }
    }
    
}
