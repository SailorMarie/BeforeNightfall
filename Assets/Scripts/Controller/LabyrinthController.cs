using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabyrinthController : MonoBehaviour
{
    [SerializeField] private LabyrinthKeyItem m_labyrinthKeyItem;
    [SerializeField] private PopUpWindow m_labyrinthWindow;
    [SerializeField] private string m_sceneAsset;

    public Action OnForestKeyPickUp;
    private PopUpWindow m_currentLabyrinthWindow;

    private PlayerInventoryController m_playerInventoryController;
    private const float WAIT_TIME = 2f;

    public void SetDependencies(GameController gameController)
    {
    }
    public void Init()
    {
        m_labyrinthKeyItem.Init(this);
        m_playerInventoryController = PlayerManager.Instance.m_inventory;
        OnForestKeyPickUp += LeaveForest;

        if (!LevelManager.Instance.IsFirstTimeLevelLoaded(SceneManager.GetActiveScene().name))
        {
           LeaveForest();
        }

    }
   

    private void LeaveForest()
    {
        OnForestKeyPickUp -= LeaveForest;

        m_currentLabyrinthWindow = (PopUpWindow)UIManager.Instance.OpenWindow(m_labyrinthWindow);
        m_currentLabyrinthWindow.Init();
        StartCoroutine(LoadForestAfterDelay());
    }
    private IEnumerator LoadForestAfterDelay()
    {
        float elapse = 0;
        
        while(elapse< WAIT_TIME)
        {
            elapse += Time.deltaTime;
            yield return null;
        }
        SceneLoaderManager.Instance.LoadScene(m_sceneAsset);
        m_currentLabyrinthWindow.Close();

    }

}
