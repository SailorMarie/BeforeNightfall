using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Window m_mainMenuWindow;
    [SerializeField] private AudioData m_backgroundSound;
    private MainMenuWindow m_currentWindow;
    void Start()
    {
        AudioManager.Instance.PlayAudio(AudioManager.AudioType.MUSIC,m_backgroundSound);
        m_currentWindow=  (MainMenuWindow)UIManager.Instance.OpenWindow(m_mainMenuWindow);
    }

   
}
