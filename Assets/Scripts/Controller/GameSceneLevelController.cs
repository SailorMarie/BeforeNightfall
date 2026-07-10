using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameSceneLevelController : LevelController
{
    [SerializeField] Window m_tutoWindow;
    [SerializeField] Transform m_LabyrinthExit;
    [SerializeField] List<PickableItem> m_Pickables;

    private PopUpController m_popUpController;


    public override void Init()
    {
        if (LevelManager.Instance.IsFirstTimeLevelLoaded(SceneManager.GetActiveScene().name))
        {
            m_popUpController.OpenPopUp(m_tutoWindow);
        }
        else
        {
            PlayerManager.Instance.SetPlayerPosition(m_LabyrinthExit,m_LabyrinthExit.rotation);
        }
            RemoveAlreadyPickedUpItem();

    }

    private void RemoveAlreadyPickedUpItem()
    {
        List<string> pickedUpItemIds = LevelManager.Instance.GetPickedUpItem();
        foreach(PickableItem pickable in m_Pickables)
        {
            if (pickedUpItemIds.Contains(pickable.m_guid))
            {
                Destroy(pickable.gameObject);
            }
        }
    }

    public override void SetDependencies(GameController gameController)
    {
     m_popUpController = gameController.popUpController;
    }
}
