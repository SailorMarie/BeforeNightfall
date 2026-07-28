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

    public void SetCabinToCorrectStep()
    {
        
        int step = LevelManager.Instance.M_cabinState;
        if(step < 0)
        {
            return;
        }else if (step > m_teleportationPoint.Count-1)
        {
            step = m_teleportationPoint.Count-1;
        }

        for (int i = 0; i <= step; i++)
        {
            m_teleportationPoint[i].DisableTeleporter();
        }
        Teleport(m_teleportationPoint[step].GetDestination());
    }
}
