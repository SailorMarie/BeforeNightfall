using UnityEngine;

public class CabinTrigger : MonoBehaviour
{
    private ToCabinController m_toCabinController;
    private BoxCollider m_boxCollider;
    public void Initialize(ToCabinController toCabinController)
    {
        m_toCabinController = toCabinController;
        m_boxCollider = GetComponent<BoxCollider>();
        m_boxCollider.enabled = false;
    }

    public void EnableTrigger()
    {
        m_boxCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        m_toCabinController.OnCabinReached?.Invoke();
    }
}
