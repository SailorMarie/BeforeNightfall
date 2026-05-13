using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public CabinTeleportController cabinTeleportController { private set; get; }
    public RespawnController respawnController { private set; get; }
    public SanityController sanityController { private set; get; }
    public PlayerManager playerManager { private set; get; }
    public CraftingStationController craftingStationController { private set; get; }
    public CraftingController craftingController { private set; get; }
    

    private void Awake()
    {
        playerManager = GetComponentInChildren<PlayerManager>();
        cabinTeleportController = GetComponentInChildren<CabinTeleportController>();
        respawnController = GetComponentInChildren<RespawnController>();
        sanityController = GetComponentInChildren<SanityController>();
        craftingStationController = GetComponentInChildren<CraftingStationController>();
        craftingController = GetComponentInChildren<CraftingController>();
        

        cabinTeleportController?.SetDependencies(this);
        respawnController?.SetDependencies(this);
        sanityController?.SetDependencies(this);
        craftingStationController?.SetDependencies(this);
        craftingController?.SetDependencies(this);


    }

    private void Start()
    {
        cabinTeleportController?.Init();
        respawnController?.Init();
        sanityController?.Init();
        craftingStationController?.Init();
        craftingController?.Init();
        
        
    }
}
