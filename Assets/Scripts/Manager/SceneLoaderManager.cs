using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager: MonoBehaviour
{
    public static SceneLoaderManager Instance { private set; get; }

    [SerializeField] private LoadingScene m_loadingScene;

    private const string GAME_SCENE = "Game";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadAndAddSceneToLevelManager(string sceneName)
    {
        m_loadingScene.LoadLevel(sceneName);
    }
    public void LoadScene(string sceneName)
    {
        m_loadingScene.LoadSceneWithTransition(sceneName);
    }

}
