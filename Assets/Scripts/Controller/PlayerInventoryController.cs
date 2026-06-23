using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryController : MonoBehaviour
{
    private Dictionary<Items, int> m_inventory = new Dictionary<Items, int>();

    [SerializeField] private Window m_inventoryWindow;
    private InventoryWindow m_currentInventoryWindow;

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
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

    public Items[] GetAllItemsInInventory()
    {
        return m_inventory.Keys.Where(x=> m_inventory[x] > 0).ToArray();
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
    }

    public void ShowInventory()
    {
        if (m_currentInventoryWindow != null)
        {
            EnablePlayerActionMap();
            m_currentInventoryWindow.Close();
            m_currentInventoryWindow = null;
        }
        else
        {
            EnableUIActionMap();
            m_currentInventoryWindow = (InventoryWindow)UIManager.Instance.OpenWindow(m_inventoryWindow);
            m_currentInventoryWindow.Initialize(this);
        }
    }

    public Items GetItemAtIndex(int index)
    {
       return m_inventory.Keys.Where(x => m_inventory[x] > 0).ToArray()[index];
    }

    public int GetItemIndex(Items item)
    {
        return m_inventory.Keys.ToList().IndexOf(item);
    }

    public void EnablePlayerActionMap()
    {
        Cursor.lockState = CursorLockMode.Locked;
        InputSystem.actions.actionMaps[1].Disable();
        InputSystem.actions.actionMaps[0].Enable();
    }

    public void EnableUIActionMap()
    {
        Cursor.lockState = CursorLockMode.Confined;
        InputSystem.actions.actionMaps[0].Disable();
        InputSystem.actions.actionMaps[1].Enable();
    }
}
