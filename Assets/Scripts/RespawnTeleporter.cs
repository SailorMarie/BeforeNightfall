using UnityEngine;

public class RespawnTeleporter : Teleporter
{
    private const string PLAYER_LAYER = "Player";

    private RespawnController m_respawnController;

    public override void Init(GameController gameController)
    {
        m_respawnController = gameController.respawnController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(PLAYER_LAYER))
        {
            m_respawnController.OnRespawnPointReach?.Invoke(m_destination);
        }
    }
}
