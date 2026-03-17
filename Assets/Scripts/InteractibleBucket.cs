using System.Collections.Generic;
using UnityEngine;

public class InteractibleBucket : Interactible
{
    [SerializeField] private Items m_itemToDrop;
    [SerializeField] private List<GameObject> m_bones;
    [SerializeField] private GameObject m_doorToDestroy;
    
    private int m_boneInPlace = 0;

    

    public override void Interact()
    {
        if(PlayerManager.Instance.HasItem(m_itemToDrop))
        {
            m_boneInPlace++;
            UpdateVisual();
            PlayerManager.Instance.RemoveItem(m_itemToDrop);
            if(m_boneInPlace == m_bones.Count)
            {
                UnlockDoor();
            }

        }
       
    }

    private void UnlockDoor()
    {
        if(m_doorToDestroy != null)
        {
            Destroy(m_doorToDestroy);
        }
        
    }

    private void UpdateVisual()
    {
        for (int i = 0; i < m_boneInPlace; i++)
        {
            m_bones[i].SetActive(true);
        }
    }
}
