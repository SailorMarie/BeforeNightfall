using UnityEngine;

public class CabinTeleporter : Teleporter
{
    private const string PLAYER_LAYER = "Player";
    
    private CabinTeleportController m_cabinTeleportController;


    public override void Init(GameController gameController)
    {
        m_cabinTeleportController = gameController.cabinTeleportController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(PLAYER_LAYER))
        {
            m_cabinTeleportController.OnTeleporterReach?.Invoke(m_destination);
            m_teleportZone.enabled = false;
        }
    }
    
}
