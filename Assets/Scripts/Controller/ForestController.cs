using System;
using UnityEngine;

public class ForestController : MonoBehaviour
{
    [SerializeField] private string m_labyrinthScene;
    [SerializeField] private Items m_keyItemNeeded;
    [SerializeField] private EnterLabyrinthTrigger m_enterLabyrinthTrigger;

    [SerializeField] private WarningBeforeLabyrinthWindow m_warningBeforeLabyrinthWindow;
    private WarningBeforeLabyrinthWindow m_currentWarningBeforeLabyrinthWindow;

    public Action OnPlayerEnterLabyrinthTrigger;
    public Action OnPlayerLeaveLabyrinthTrigger;

    private PlayerInventoryController m_inventoryController;
    public void SetDependencies(GameController gameController)
    {

    }

    public void Init()
    {
        m_inventoryController = PlayerManager.Instance.m_inventory;
        m_enterLabyrinthTrigger.Init(this);
        OnPlayerEnterLabyrinthTrigger += TryEnterLabyrinth;
        OnPlayerLeaveLabyrinthTrigger += CloseWarning;
    }

    private void OnDestroy()
    {
        OnPlayerEnterLabyrinthTrigger -= TryEnterLabyrinth;
        OnPlayerLeaveLabyrinthTrigger -= CloseWarning;


    }

    public void TryEnterLabyrinth()
    {
        if (m_inventoryController.HasItem(m_keyItemNeeded))
        {
            SceneLoaderManager.Instance.LoadScene(m_labyrinthScene);
        }
        else
        {
            m_currentWarningBeforeLabyrinthWindow = (WarningBeforeLabyrinthWindow)UIManager.Instance.OpenWindow(m_warningBeforeLabyrinthWindow);
        }
    }

    public void CloseWarning()
    {
        if (m_currentWarningBeforeLabyrinthWindow != null)
        {
            m_currentWarningBeforeLabyrinthWindow.Close();
            m_currentWarningBeforeLabyrinthWindow = null;
        }
    }
}
