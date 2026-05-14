using System.Collections;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class LabyrinthController : MonoBehaviour
{
    [SerializeField] private Items m_forestKeyItem;
    [SerializeField] private LabyrinthWindow m_labyrinthWindow;
    [SerializeField] private SceneAsset m_sceneAsset;
    private LabyrinthWindow m_currentLabyrinthWindow;

    private PlayerInventoryController m_playerInventoryController;
    private const float WAIT_TIME = 2f;

    public void SetDependencies(GameController gameController)
    {
        m_playerInventoryController = gameController.playerManager.m_inventory;
    }
    public void Init()
    {

        StartCoroutine(WaitForItemToBePickUp());
    }
    private IEnumerator WaitForItemToBePickUp()
    {
        while (!m_playerInventoryController.HasItem(m_forestKeyItem))
        {
            yield return null;  
        }
            m_currentLabyrinthWindow = (LabyrinthWindow)UIManager.Instance.OpenWindow(m_labyrinthWindow);
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
        SceneLoaderManager.Instance.LoadScene(m_sceneAsset.name);
        m_currentLabyrinthWindow.Close();

    }

}
