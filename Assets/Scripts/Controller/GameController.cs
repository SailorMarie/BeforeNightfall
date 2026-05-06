using UnityEngine;

public class GameController : MonoBehaviour
{

    //ui

    public CabinTeleportController cabinTeleportController { private set; get; }
    public RespawnController respawnController { private set; get; }
    public SanityController sanityController { private set; get; }

    private void Awake()
    {
        cabinTeleportController = GetComponentInChildren<CabinTeleportController>();
        respawnController = GetComponentInChildren<RespawnController>();
        sanityController = GetComponentInChildren<SanityController>();

        cabinTeleportController.SetDependencies(this);

        cabinTeleportController.Init();
    }
}
