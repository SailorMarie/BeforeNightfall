using UnityEngine;

public class CabinTrigger : MonoBehaviour
{
    private ToCabinController m_toCabinController;

    public void Initialize(ToCabinController toCabinController)
    {
        m_toCabinController = toCabinController;
    }

    private void OnTriggerEnter(Collider other)
    {
        m_toCabinController.OnCabinReached?.Invoke();
    }
}
