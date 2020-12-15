
using System;
using Inventory.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory_Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Item item;
    public Image icon;
    public Button RemoveButton;
    [SerializeField] private ItemToolTip _toolTip;
    private Color color_icon;
    public Vector2 coord;

    private void Awake()
    {
        if (_toolTip == null)
        {
            _toolTip = ItemToolTip.ToolTip;
        }
    }

    private void Start()
    {
        if (_toolTip == null)
        {
            _toolTip = ItemToolTip.ToolTip;
        }
        color_icon = icon.color;
        coord = icon.transform.position;
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        RemoveButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false; 
        RemoveButton.interactable = false;

    }

    public void OnRemoveButton()
    {
        Inventory.Scripts.Inventory.instance.Remove(item);
    }
    
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _toolTip.ShowToolTip((Equipment) item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _toolTip.HideToolTip();
    }

    protected virtual void OnValidate()
    {
        if (icon == null)
        {
            icon = GetComponent<Image>();
        }

        if (_toolTip == null)
        {
            _toolTip = ItemToolTip.ToolTip;
        }
    }



    public void makeTransparent()
    {
        icon.color = new Color(1,1,1,0.5f);
    }

    public void makeNonTransparent()
    {
        icon.color = new Color(1,1,1,1);;
    }
    public Item getItem()
    {
        return item;
    }
}
