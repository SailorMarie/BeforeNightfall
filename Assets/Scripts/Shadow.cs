using UnityEngine;

public class Shadow : MonoBehaviour
{
    private const string PLAYER_LAYER = "Player";

    [SerializeField] protected BoxCollider m_shadowZone;

    private SanityController m_sanityController;

    public void Init(SanityController sanityController)
    {
        m_sanityController = sanityController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(PLAYER_LAYER))
        {
            m_sanityController.OnSanityLostStart?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(PLAYER_LAYER))
        {
            m_sanityController.OnSanityLostStop?.Invoke();
        }
    }
}
