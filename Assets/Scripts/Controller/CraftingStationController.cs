using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingStationController : MonoBehaviour
{
   
    private bool m_playerHasItems;
    public PlayerInventoryController m_playerInventoryController;
    [SerializeField] private List<InteractibleCraftStation> m_interactibleCraftStation;

    [SerializeField] private Window m_craftingWindow;
    private CraftingWindow m_currentCraftingWindow;
    public InteractibleCraftStation m_currentCraftingStation;
    private CraftingController m_craftingController;
    public Action<int> OnIngredientSelected;
    public Action<Vector3, Vector3> OnCraftButtonPressed;

    public Action<Items,int> FirstIngredientSelected;
    public Action<int> FirstIngredientUnselected;
    public Action<Items,int> SecondIngredientSelected;
    public Action<int> SecondIngredientUnselected;
    public Action<Items> CraftResultSelected;
    public Action OnInventoryRefresh;
    public Action OnCraftingClose;

    public void SetDependencies(GameController gameController)
    {
        m_craftingController = gameController.craftingController;
    }

    public void Init()
    {
        m_playerInventoryController = PlayerManager.Instance.m_inventory;
        foreach(var interactibleCraftStation in m_interactibleCraftStation)
        {
            interactibleCraftStation.Init(this);
        }
    }

    //REFACTOR a mettre dans le player input controller
    public void CloseCraftingWindow(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InputAction action = InputSystem.actions.FindAction("Interact");
            if (action.WasPressedThisFrame())
            {

                if (m_currentCraftingWindow != null)
                {
                    OnCraftingClose?.Invoke();
                    m_playerInventoryController.EnablePlayerActionMap();
                    m_currentCraftingWindow.Close();
                    m_currentCraftingWindow = null;
                }
            }

        }
        
    }

    public void Interact(InteractibleCraftStation currentCraftingStationPosition)
    {
        if (m_playerInventoryController == null)     
        {
            m_playerInventoryController = PlayerManager.Instance.m_inventory;
        }
        m_playerHasItems = true;
        if (m_currentCraftingWindow != null)
        {
            m_currentCraftingStation = null;
            m_playerInventoryController.EnablePlayerActionMap();
            m_currentCraftingWindow.Close();
            m_currentCraftingWindow = null;
        }
        else
        {
            m_currentCraftingStation = currentCraftingStationPosition;
            m_playerInventoryController.EnableUIActionMap();
            m_playerInventoryController.GetAllItemsInInventory();
            m_currentCraftingWindow = (CraftingWindow)UIManager.Instance.OpenWindow(m_craftingWindow);
            m_currentCraftingWindow.Initialize(this);
        }
        
    }

}
