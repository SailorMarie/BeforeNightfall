using UnityEngine;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private Image m_Background;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public async void LoadLevel(string SceneToLoad)
    {
        AsyncOperation loadOp = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneToLoad);
        m_Background.enabled = true;
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
            m_Background.enabled = false;
        }

    }   
}
