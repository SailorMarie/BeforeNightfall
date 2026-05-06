using System;
using System.Collections.Generic;
using UnityEngine;

public class CabinTeleportController : MonoBehaviour
{
    [SerializeField] private List<CabinTeleporter> m_teleportationPoint;
    [SerializeField] private Transform m_cabin;
    private GameController m_gameController;

    public Action<Transform> OnTeleporterReach;

    public void SetDependencies(GameController gameController)
    {
        m_gameController = gameController;
    }

    public void Init()
    {
        OnTeleporterReach += Teleport;
        foreach (CabinTeleporter teleporter in m_teleportationPoint)
        {
            teleporter.Init(m_gameController);
        }
    }

    public void Teleport(Transform destination)
    {
        m_cabin.transform.position = destination.position;
    }
}
