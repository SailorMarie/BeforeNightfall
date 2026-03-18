using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InteractibleCraftStation : Interactible
{
    [SerializeField] private Recipes m_recipes;
    private bool m_playerHasItems;
    private Vector3 m_posCraftTable;

    private void Awake()
    {
        m_posCraftTable = transform.position;
    }


    public override void Interact()
    {
        m_playerHasItems = true;
        for(int i = 0; i < m_recipes.m_ingredients.Count; i++)
        {
            //PlayerManager.Instance.HasItem(m_recipes.m_ingredients[i]);
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
            
            PlayerManager.Instance.CraftingItem(m_recipes.m_result, m_posCraftTable);
        }
    }
}
