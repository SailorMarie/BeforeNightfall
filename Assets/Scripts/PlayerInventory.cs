using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<Items, int> m_inventory = new Dictionary<Items, int>();

    [SerializeField] private Window m_inventoryWindow;
    private InventoryWindow m_currentInventoryWindow;

    public void AddItem(Items item)
    {
        if(!m_inventory.ContainsKey(item))
        {
            m_inventory.Add(item, 0);
        }
        m_inventory[item] += 1;
    }

    public void RemoveItem(Items item)
    {
        if(m_inventory.ContainsKey(item) && m_inventory[item] > 0)
        {
            m_inventory[item]--;
        }
    }

    public bool HasItem(Items item)
    {
        return m_inventory.ContainsKey(item) && m_inventory[item] > 0;
    }

    public void DropItem(Items item, Vector3 spawnPosition)
    {
        if (m_inventory.ContainsKey(item) && m_inventory[item] > 0)
        {
            Instantiate(item.Prefab, spawnPosition, Quaternion.identity);
            RemoveItem(item);

        }
    }

    public void CraftingItem(Items item, Vector3 spawnPosition)
    {
        Instantiate(item.Prefab, spawnPosition, Quaternion.identity);
        AddItem(item);
    }

    public void ShowInventory()
    {
        if (m_currentInventoryWindow != null)
        {
            m_currentInventoryWindow.Close();
            m_currentInventoryWindow = null;
        }
        else
        {
            m_currentInventoryWindow = (InventoryWindow)UIManager.Instance.OpenWindow(m_inventoryWindow);
            m_currentInventoryWindow.Initialize(this);
        }
    }
}
