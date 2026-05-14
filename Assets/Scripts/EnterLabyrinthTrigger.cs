using UnityEngine;

public class EnterLabyrinthTrigger : MonoBehaviour
{
    private ForestController m_forestController;

    public void Init(ForestController forestController)
    {
        m_forestController = forestController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_forestController != null) 
        {
            m_forestController.OnPlayerEnterLabyrinthTrigger?.Invoke();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (m_forestController != null)
        {
            m_forestController.OnPlayerLeaveLabyrinthTrigger?.Invoke();
        }
    }
}
