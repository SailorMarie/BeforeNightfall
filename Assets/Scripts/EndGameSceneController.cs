using UnityEngine;

public class EndGameWindow : MonoBehaviour
{
    private const string MAIN_MENU = "GameMenuScene";
    [SerializeField] private GameObject m_loadingPanel;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void RestartGame() 
    {
        m_loadingPanel.SetActive(true);
        LevelManager.Instance.Reset();
        PlayerManager.Instance.Destroy();
        SceneLoaderManager.Instance.LoadScene(MAIN_MENU);   
    }

    public void Quit()
    {
        Application.Quit();
    }
}
