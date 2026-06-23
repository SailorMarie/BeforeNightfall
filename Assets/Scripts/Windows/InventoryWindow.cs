using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : Window
{
    private PlayerInventoryController m_playerInventory;
    [SerializeField] private List<Image> m_inventorySlot;
    [SerializeField] private Image m_selectedItemIcon;
    [SerializeField] private TextMeshProUGUI m_selectedItemName;
    [SerializeField] private TextMeshProUGUI m_selectedItemDescription;

    private Items m_currentSelectedItem = null;

    public void Initialize(PlayerInventoryController playerInventory)
    {
        m_playerInventory = playerInventory;
        int index = 0;
        foreach(var item in m_playerInventory.GetAllItemsInInventory())
        {
            m_inventorySlot[index].sprite = item.Sprite;
            index++;
        }
    }

    public void ItemClick(int index)
    {
        Items item = m_playerInventory.GetAllItemsInInventory()[index];
        if(item != null || item != m_currentSelectedItem)
        {
            m_selectedItemIcon.sprite = item.Sprite;
            m_selectedItemName.text = item.Name;
            m_selectedItemDescription.text = item.Description;
            m_currentSelectedItem = item;
        }
        else
        {
            m_selectedItemIcon.sprite = null;
            m_selectedItemName.text = "";
            m_selectedItemDescription.text = "";
            m_currentSelectedItem = null;
        }
    }
}
