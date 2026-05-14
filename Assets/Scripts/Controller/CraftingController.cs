using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CraftingController : MonoBehaviour
{
    [SerializeField] private List<Recipes> m_Recipes;
    private CraftingStationController m_craftingStationController;
    private PlayerInventoryController m_playerInventoryController;
    private Items m_firstIngredient;
    private Items m_secondIngredient;
    private Recipes m_currentRecipe;

    public void SetDependencies(GameController gameController)
    {
        m_craftingStationController = gameController.craftingStationController;
    }

    public void Init()
    {
        m_playerInventoryController = PlayerManager.Instance.m_inventory;
        m_craftingStationController.OnIngredientSelected += AddIngredient;
        m_craftingStationController.OnCraftButtonPressed += Craft;
    }

    private void AddIngredient(int ingredientIndex)
    {
        m_playerInventoryController.GetItemAtIndex(ingredientIndex);
        if(m_firstIngredient == null)
        {
            m_firstIngredient = m_playerInventoryController.GetItemAtIndex(ingredientIndex);
            m_craftingStationController.FirstIngredientSelected?.Invoke(m_firstIngredient);
        }
        else if(m_firstIngredient == m_playerInventoryController.GetItemAtIndex(ingredientIndex))
        {
            m_firstIngredient = null;
            m_craftingStationController.FirstIngredientUnselected?.Invoke();   
        }
        else if(m_secondIngredient == null)
        {
            m_secondIngredient = m_playerInventoryController.GetItemAtIndex(ingredientIndex);
            m_craftingStationController.SecondIngredientSelected?.Invoke(m_secondIngredient);
        }
        else if(m_secondIngredient == m_playerInventoryController.GetItemAtIndex(ingredientIndex))
        {
            m_secondIngredient = null;
            m_craftingStationController.SecondIngredientUnselected?.Invoke();
        }

        CheckRecipes();
    }

    private void CheckRecipes()
    {
        foreach( var recipe in m_Recipes)
        {
            if ((recipe.m_ingredients[0] == m_firstIngredient && recipe.m_ingredients[1] == m_secondIngredient) || (recipe.m_ingredients[1] == m_firstIngredient && recipe.m_ingredients[0] == m_secondIngredient))
            {
                m_currentRecipe = recipe;
                m_craftingStationController.CraftResultSelected?.Invoke(recipe.m_result);
                break;
            }
            else
            {
                Debug.Log("Cant craft");
            }
        }
    }

    private void Craft(Vector3 posCraftable, Vector3 craftingHeight)
    {
        for (int i = 0; i < m_currentRecipe.m_ingredients.Count; i++)
        {
            PlayerManager.Instance.RemoveItem(m_currentRecipe.m_ingredients[i]);
        }

        m_craftingStationController.OnInventoryRefresh?.Invoke();
        m_craftingStationController.FirstIngredientUnselected?.Invoke();
        m_craftingStationController.SecondIngredientUnselected?.Invoke();
        m_firstIngredient = null;
        m_secondIngredient = null;
        PlayerManager.Instance.CraftingItem(m_currentRecipe.m_result, posCraftable + craftingHeight);
        
    }
}
