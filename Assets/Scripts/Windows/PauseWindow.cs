using UnityEngine;

public class PauseWindow : Window
{

    private PauseWindowController m_pauseWindowController;

    public void Init(PauseWindowController pauseWindowController)
    {
        m_pauseWindowController = pauseWindowController;
    }
    public void Resume()
    {
        m_pauseWindowController.CloseWindow();
    }
    public void CloseGame()
    {
        m_pauseWindowController.Quit();
    }
}
