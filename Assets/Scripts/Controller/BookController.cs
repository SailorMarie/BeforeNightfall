using UnityEngine;

public class BookController : MonoBehaviour
{
    [SerializeField] Window m_bookWindow;
    private BookWindow m_currentWindow;

    private void Start()
    {
        m_currentWindow = (BookWindow)UIManager.Instance.OpenWindow(m_bookWindow);
    }

    private void OnDestroy()
    {
        m_currentWindow.Close();
    }
}
