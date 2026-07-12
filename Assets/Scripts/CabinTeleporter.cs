using System;
using UnityEngine;

public class CabinTeleporter : Teleporter
{
    private const string PLAYER_LAYER = "Player";
    [SerializeField] private Window m_popUpWindow;

    private CabinTeleportController m_cabinTeleportController;
    private PopUpController m_popUpController;
    private CameraEffectController m_cameraEffectController;
    

    public override void Init(GameController gameController)
    {
        m_cabinTeleportController = gameController.cabinTeleportController;
        m_popUpController = gameController.popUpController;
        m_cameraEffectController = gameController.cameraEffectController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(PLAYER_LAYER))
        {
            m_cabinTeleportController.OnTeleporterReach?.Invoke(m_destination);
            m_cameraEffectController.OnTeleportEffect?.Invoke();
            m_popUpController?.OpenPopUp(m_popUpWindow);
            DisableTeleporter();
            LevelManager.Instance.IncreaseCabinState();
        }
    }
    public void DisableTeleporter()
    {
        m_teleportZone.enabled = false;
    }
    
}
