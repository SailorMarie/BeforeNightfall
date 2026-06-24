using UnityEngine;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private GameObject m_Background;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public async void LoadLevel(string SceneToLoad)
    {
        LevelManager.Instance.AddLevel(SceneToLoad);
        AsyncOperation loadOp = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneToLoad);
        m_Background.SetActive(true);
        loadOp.allowSceneActivation = false;

        while (!loadOp.isDone)
        {
            if (loadOp.progress >= 0.9f)
            {
                loadOp.allowSceneActivation = true;
            }

            await System.Threading.Tasks.Task.Yield();
        }
        if(m_Background != null)
        {
            m_Background.SetActive(false);
        }

    }   
}
