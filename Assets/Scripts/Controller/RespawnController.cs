using System;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [SerializeField] private List<RespawnTeleporter> m_respawnZone;

    private PlayerManager m_playerManager;
    private GameController m_gameController;

    public Action<Transform> OnRespawnPointReach;

    public void SetDependencies(GameController gameController)
    {
        m_playerManager = gameController.playerManager;
        m_gameController = gameController;

    }

    public void Init()
    {
        OnRespawnPointReach += Respawn;
        foreach (RespawnTeleporter teleporter in m_respawnZone)
        {
            teleporter.Init(m_gameController);
        }
    }

    public void Respawn(Transform destination)
    {
        m_playerManager.SetPlayerPosition(destination);
        
    }
}
