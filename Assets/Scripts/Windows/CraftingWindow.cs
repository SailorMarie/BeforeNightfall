using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingWindow : Window
{
    private InteractibleCraftStation m_interactibleCraftStation;
    [SerializeField] private List<Image> m_inventorySlot;

    public void Initialize(InteractibleCraftStation interactibleCraftStation)
    {
        m_interactibleCraftStation = interactibleCraftStation;
        int index = 0;
        //foreach (var item in m_playerInventory.GetAllItemsInInventory())
        //{
        //    m_inventorySlot[index].sprite = item.Sprite;
        //}
    }
}
