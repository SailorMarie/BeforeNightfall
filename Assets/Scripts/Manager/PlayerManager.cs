using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public Action m_interact;
    [SerializeField] public PlayerInventoryController m_inventory;
    [SerializeField] private Transform m_player;
    private int m_boneInPlace = 0;
    private float m_maxSanity = 100;
    private float m_currentSanity = 100;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
            DontDestroyOnLoad(gameObject);
    }
    public void SetPlayer(Transform player)
    {
        if(m_player == null)
        {
            m_player = player;
        }
    }

    public void AddItem(Items itemToAdd)
    {
        if(!m_inventory.HasItem(itemToAdd))
        {
            //appeler ui pour show le pickup
        }
        m_inventory.AddItem(itemToAdd);
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
        m_inventory.ShowInventory();
    }

    public bool HasItem(Items itemToDrop)
    {
        return m_inventory.HasItem(itemToDrop);
    }

    public void CraftingItem(Items Item, Vector3 spawnPosition)
    {
        m_inventory.CraftingItem(Item, spawnPosition);
    }

    public void SetPlayerPosition(Transform destination)
    {
        m_player.transform.position = destination.position;
        Rigidbody rb = m_player.GetComponent<Rigidbody>();
        if (rb != null) rb.linearVelocity = Vector3.zero;
    }
    public void SetPlayerPosition(Transform destination,Quaternion rotation)
    {
        SetPlayerPosition(destination);
        m_player.rotation = rotation;
    }

    public float GetSanaity()
    {
        return m_currentSanity;
    }
    public void RemoveSanity(float sanityToRemove)
    {
        m_currentSanity -= sanityToRemove;
    }
    public void SetSanity(float sanity)
    {
        m_currentSanity = sanity;
    }

    public void AddBoneKey()
    {
        m_boneInPlace++;
    }
    public int GetNumberOfBonePLace()
    {
        return m_boneInPlace;
    }

    public float GetMaxSanity()
    {
        return m_maxSanity;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
