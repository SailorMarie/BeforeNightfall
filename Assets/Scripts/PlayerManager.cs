using System;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public Action m_interact;
    [SerializeField] private PlayerInventory m_inventory;

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(Items itemToAdd)
    {
        if(!m_inventory.HasItem(itemToAdd))
        {
            //appeler ui pour show le pickup
        }
        m_inventory.AddItem(itemToAdd);
        m_inventory.ShowInventory();
    }

    public void RemoveItem(Items itemToRemove)
    {
        m_inventory.RemoveItem(itemToRemove);
    }

    public void DropItem(Items itemToDrop, Vector3 spawnPosition)
    {
        m_inventory.DropItem(itemToDrop, spawnPosition);
    }

    public void ShowInventory()
    {
        
    }

    public bool HasItem(Items itemToDrop)
    {
        return m_inventory.HasItem(itemToDrop);
    }

    public void CraftingItem(Items Item, Vector3 spawnPosition)
    {
        m_inventory.CraftingItem(Item, spawnPosition);
    }

    
}
