using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

public class InteractibleCraftStation : Interactible
{
    [SerializeField] private Recipes m_recipes;
    private bool m_playerHasItems;
    private Vector3 m_posCraftTable;
    private Vector3 m_craftingTableHeight = new Vector3(0, 1.3f, 0);

    private void Awake()
    {
        m_posCraftTable = transform.position;
       
    }


    public override void Interact()
    {
        m_playerHasItems = true;
        for(int i = 0; i < m_recipes.m_ingredients.Count; i++)
        {
            
            if (!PlayerManager.Instance.HasItem(m_recipes.m_ingredients[i]))
            {
                m_playerHasItems = false;
                Debug.Log("Cant Craft");
            }
            
        }
        if(m_playerHasItems)
        {
            for (int i = 0; i < m_recipes.m_ingredients.Count; i++)
            {
                PlayerManager.Instance.RemoveItem(m_recipes.m_ingredients[i]);
            }
            
            PlayerManager.Instance.CraftingItem(m_recipes.m_result, m_posCraftTable + m_craftingTableHeight);
        }
    }
}
