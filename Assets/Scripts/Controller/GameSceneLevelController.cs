using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameSceneLevelController : LevelController
{
    [SerializeField] Window m_tutoWindow;

    
    private Window m_currentWindow;

    public override void ClosePopUp(InputAction.CallbackContext context)
    {
        if(context.performed && m_currentWindow != null)
        {
            m_currentWindow.Close();
            m_currentWindow = null;

        }
    }

    public override void Init()
    {
        if (LevelManager.Instance.IsFirstTimeLevelLoaded(SceneManager.GetActiveScene().name))
        {
            m_currentWindow= UIManager.Instance.OpenWindow(m_tutoWindow);
        }

    }

    public override void SetDependencies(GameController gameController)
    {
     
    }
}
