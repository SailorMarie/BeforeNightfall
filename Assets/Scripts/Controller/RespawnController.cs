using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [SerializeField] private Transform m_respawnPoint;
    [SerializeField] private Transform m_player;


    public void SetDependencies(GameController gameController)
    {

    }

    public void Init()
    {
    }

    public void Respawn()
    {
        //faire une coroutine
        m_player.transform.position = m_respawnPoint.position;
        Rigidbody rb = m_player.GetComponent<Rigidbody>();
        if (rb != null) rb.linearVelocity = Vector3.zero;
    }
}
