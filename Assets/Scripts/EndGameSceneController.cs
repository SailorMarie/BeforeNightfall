using UnityEngine;

public class EndGameWindow : MonoBehaviour
{
    private const string FIRST_SCENE = "First_Scene";
    [SerializeField] private GameObject m_loadingPanel;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void RestartGame() 
    {
        m_loadingPanel.SetActive(true);
        SceneLoaderManager.Instance.LoadAndAddSceneToLevelManager(FIRST_SCENE);   
    }

    public void Quit()
    {
        Application.Quit();
    }
}
