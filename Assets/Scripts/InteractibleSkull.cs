using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleSkull : Interactible
{
    [SerializeField] private Items m_itemToDrop;
    [SerializeField] private List<GameObject> m_bones;
    [SerializeField] private GameObject m_doorToDestroy;
    private ToCabinController m_controller;

    public Action OnUnlockDoor;

    public override void Interact()
    {
        if(PlayerManager.Instance.HasItem(m_itemToDrop))
        {
            PlayerManager.Instance.AddBoneKey();
            UpdateVisual();
            PlayerManager.Instance.RemoveItem(m_itemToDrop);
            if(PlayerManager.Instance.GetNumberOfBonePLace() == m_bones.Count)
            {
                UnlockDoor();
            }
        }
    }

    public void Init(ToCabinController controller)
    {
        m_controller = controller;
        UpdateVisual();
    }

    private void UnlockDoor()
    {
        if(m_doorToDestroy != null)
        {
            Destroy(m_doorToDestroy);
        }
        OnUnlockDoor?.Invoke();

    }

    private void UpdateVisual()
    {
        for (int i = 0; i < PlayerManager.Instance.GetNumberOfBonePLace(); i++)
        {
            m_bones[i].SetActive(true);
        }
    }
}
