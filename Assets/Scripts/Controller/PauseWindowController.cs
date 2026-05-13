using UnityEngine;
using UnityEngine.InputSystem;

public class PauseWindowController : MonoBehaviour
{

    [SerializeField] private PauseWindow m_pauseWindow;
    private PauseWindow m_currentWindow;
    private InputAction m_pause;
    public void SetDependencies(GameController gameController)
    {

    }

    public void Init()
    {
    }
    public void OnPauseOpen(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_pause = InputSystem.actions.FindAction("Pause");

            if (m_pause.WasPressedThisFrame())
            {

                m_currentWindow = (PauseWindow)UIManager.Instance.OpenWindow(m_pauseWindow);
                m_currentWindow.Init(this);

                Cursor.lockState = CursorLockMode.Confined;
                InputSystem.actions.actionMaps[0].Disable();
                InputSystem.actions.actionMaps[1].Enable();
            }

        }
    }

    public void OnPauseClose(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_pause = InputSystem.actions.FindAction("Pause");

            if (m_pause.WasPressedThisFrame())
            {
                
                CloseWindow();
            }

        }
    }

    public void CloseWindow()
    {
        if (m_currentWindow != null)
        {
            Cursor.lockState = CursorLockMode.Locked;

            InputSystem.actions.actionMaps[1].Disable();
            InputSystem.actions.actionMaps[0].Enable();
            m_currentWindow.Close();
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
