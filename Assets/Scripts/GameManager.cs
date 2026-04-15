using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private CabinTeleport cabinTeleport;
    private RespawnManager respawnManager;
    private SanityManager sanityManager;

    private void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
        }

        cabinTeleport = GetComponentInChildren<CabinTeleport>();
        respawnManager = GetComponentInChildren<RespawnManager>();
        sanityManager = GetComponentInChildren<SanityManager>();
    }
}
