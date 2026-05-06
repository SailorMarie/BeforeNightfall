using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingWindow : Window
{
    private InteractibleCraftStation m_interactibleCraftStation;
    [SerializeField] private List<Image> m_inventorySlot;
    [SerializeField] private List<ScriptableObject> m_scriptableObject;

    public void Initialize(InteractibleCraftStation interactibleCraftStation)
    {
        m_interactibleCraftStation = interactibleCraftStation;
    }
}
