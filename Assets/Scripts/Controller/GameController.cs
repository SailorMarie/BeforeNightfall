using UnityEngine;

public class GameController : MonoBehaviour
{
    public CabinTeleportController cabinTeleportController { private set; get; }
    public RespawnController respawnController { private set; get; }
    public SanityController sanityController { private set; get; }
    public PlayerManager playerManager { private set; get; }

    private void Awake()
    {
        playerManager = GetComponentInChildren<PlayerManager>();
        cabinTeleportController = GetComponentInChildren<CabinTeleportController>();
        respawnController = GetComponentInChildren<RespawnController>();
        sanityController = GetComponentInChildren<SanityController>();

        cabinTeleportController?.SetDependencies(this);
        respawnController?.SetDependencies(this);
        sanityController?.SetDependencies(this);

        cabinTeleportController?.Init();
        respawnController?.Init();
        sanityController.Init();
    }
}
