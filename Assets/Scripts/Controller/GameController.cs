using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController Instance;

    //ui

    private CabinTeleportController cabinTeleport;
    private RespawnController respawnManager;
    private SanityController sanityManager;

    private void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
        }

        cabinTeleport = GetComponentInChildren<CabinTeleportController>();
        respawnManager = GetComponentInChildren<RespawnController>();
        sanityManager = GetComponentInChildren<SanityController>();
    }
}
