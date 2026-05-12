using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

public class InteractibleCraftStation : Interactible
{
    [SerializeField] private Recipes m_recipes;
    
    private CraftingStationController m_craftingStationController;
    
    private void Awake()
    {
        
    }

    public void Init(CraftingStationController craftingStationController)
    {
        m_craftingStationController = craftingStationController;
    }

    public override void Interact()
    {
       m_craftingStationController.Interact(this);
    }
}
