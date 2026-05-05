using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : Window
{
    private PlayerInventory m_playerInventory;
    [SerializeField] private List<Image> m_inventorySlot;

    public void Initialize(PlayerInventory playerInventory)
    {
        m_playerInventory = playerInventory;
    }
}
