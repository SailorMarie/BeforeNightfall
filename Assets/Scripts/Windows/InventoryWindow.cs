using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : Window
{
    private PlayerInventoryController m_playerInventory;
    [SerializeField] private List<Image> m_inventorySlot;

    public void Initialize(PlayerInventoryController playerInventory)
    {
        m_playerInventory = playerInventory;
    }
}
