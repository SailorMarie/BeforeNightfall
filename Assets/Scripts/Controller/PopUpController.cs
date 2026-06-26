using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PopUpController : MonoBehaviour
{
    private Window m_currentWindow;


    public void Init()
    {
       
    }

    public void SetDependencies(GameController gameController)
    {
    }
    public void ClosePopUp(InputAction.CallbackContext context)
    {
        if (context.performed && m_currentWindow != null)
        {
            m_currentWindow.Close();
            m_currentWindow = null;

        }
    }

    public void OpenPopUp(Window window)
    {
        if (m_currentWindow != null)
        {
            m_currentWindow.Close();
        }
        m_currentWindow = UIManager.Instance.OpenWindow(window);
    }
}
