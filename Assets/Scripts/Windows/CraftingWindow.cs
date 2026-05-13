using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingWindow : Window
{
    private CraftingStationController m_craftingStationController;
    [SerializeField] private List<Button> m_inventorySlot;
    
    [SerializeField] private Image m_firstIngredient;
    [SerializeField] private Image m_secondIngredient;
    [SerializeField] private Image m_result;
    [SerializeField] private Image m_ingredientSelected;
    [SerializeField] private TextMeshProUGUI m_ingredientDescription;
    [SerializeField] private Image m_craftResult;
    [SerializeField] private TextMeshProUGUI m_resultDescription;

  
    private Vector3 m_craftingTableHeight = new Vector3(0, 1.5f, 0);

    public void Initialize(CraftingStationController craftingStationController)
    {
        m_craftingStationController = craftingStationController;
        
        RefreshDisplay();

        m_craftingStationController.FirstIngredientSelected += OnFirstIngredientSelected;
        m_craftingStationController.FirstIngredientUnselected += OnFirstIngredientUnselected;
        m_craftingStationController.SecondIngredientSelected += OnSecondIngredientSelected;
        m_craftingStationController.SecondIngredientUnselected += OnSecondIngredientUnselected;
        m_craftingStationController.CraftResultSelected += UpdateResult;
        m_craftingStationController.OnInventoryRefresh += RefreshDisplay;
    }

    public void RefreshDisplay()
    {
        int index = 0;
        foreach (var item in m_craftingStationController.m_playerInventoryController.GetAllItemsInInventory())
        {
            m_inventorySlot[index].image.sprite = item.Sprite;
            m_inventorySlot[index].interactable = true;
            index++;
        }
    }

    private void OnDestroy()
    {
        m_craftingStationController.FirstIngredientSelected -= OnFirstIngredientSelected;
        m_craftingStationController.FirstIngredientUnselected -= OnFirstIngredientUnselected;
        m_craftingStationController.SecondIngredientSelected -= OnSecondIngredientSelected;
        m_craftingStationController.SecondIngredientUnselected -= OnSecondIngredientUnselected;
        m_craftingStationController.CraftResultSelected -= UpdateResult;
        m_craftingStationController.OnInventoryRefresh -= RefreshDisplay;
    }
    

    public void OnIngredientPressed(int ingredientIndex)
    {
        m_craftingStationController.OnIngredientSelected?.Invoke(ingredientIndex);
    }

    public void OnCraftButtonPressed()
    {
        m_craftingStationController.OnCraftButtonPressed?.Invoke(m_craftingStationController.m_currentCraftingStation.transform.position, m_craftingTableHeight);
    }

    public void OnFirstIngredientSelected(Items item)
    {
        m_firstIngredient.sprite = item.Sprite;
        m_ingredientSelected.sprite = item.Sprite;
        m_ingredientDescription.text = item.Description;
    }
    public void OnFirstIngredientUnselected()
    {
        m_firstIngredient.sprite = null;
        m_ingredientSelected.sprite = null;
        m_ingredientDescription.text = "";
    }
    public void OnSecondIngredientSelected(Items item)
    {
        m_secondIngredient.sprite = item.Sprite;
        m_ingredientSelected.sprite = item.Sprite;
        m_ingredientDescription.text = item.Description;
    }
    public void OnSecondIngredientUnselected()
    {
        m_secondIngredient.sprite = null;
        m_ingredientSelected.sprite = null;
        m_ingredientDescription.text = "";
    }
    public void UpdateResult(Items item)
    {
        m_result.sprite = item.Sprite;
        m_craftResult.sprite = item.Sprite;
        m_resultDescription.text = item.Description;
    }
}
