using UnityEngine;

public class PopUpTriggerZone : MonoBehaviour
{
    [SerializeField] private Window m_window;
    private Window m_CurrentWindow;
    public void OnTriggerEnter(Collider other)
    {
        m_CurrentWindow =  UIManager.Instance.OpenWindow(m_window);   
    }

    public void OnTriggerExit(Collider other)
    {
        if (m_CurrentWindow != null)
        {
            m_CurrentWindow.Close();
            
        }
    }
}
