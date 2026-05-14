using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public CabinTeleportController cabinTeleportController { private set; get; }
    public RespawnController respawnController { private set; get; }
    public SanityController sanityController { private set; get; }
    public PlayerManager playerManager { private set; get; }
    public CraftingStationController craftingStationController { private set; get; }
    public CraftingController craftingController { private set; get; }
  public PauseWindowController pauseWindowController { private set; get; }
    public EndGameController endGameController { private set; get; }
    public LabyrinthController labyrinthController { private set; get; }
    public ToCabinController ToCabinController { private set; get; }

    public ForestController forestController { private set; get; }


    private void Awake()
    {
        playerManager = PlayerManager.Instance;
        cabinTeleportController = GetComponentInChildren<CabinTeleportController>();
        respawnController = GetComponentInChildren<RespawnController>();
        sanityController = GetComponentInChildren<SanityController>();
        craftingStationController = GetComponentInChildren<CraftingStationController>();
        craftingController = GetComponentInChildren<CraftingController>();
        endGameController = GetComponentInChildren<EndGameController>();
        pauseWindowController = GetComponentInChildren<PauseWindowController>();
        labyrinthController = GetComponentInChildren<LabyrinthController>();
        ToCabinController = GetComponentInChildren<ToCabinController>();
        forestController = GetComponentInChildren<ForestController>();

        cabinTeleportController?.SetDependencies(this);
        respawnController?.SetDependencies(this);
        sanityController?.SetDependencies(this);
        craftingStationController?.SetDependencies(this);
        craftingController?.SetDependencies(this);
        endGameController?.SetDependencies(this);
        pauseWindowController?.SetDependencies(this);
        labyrinthController?.SetDependencies(this);
        ToCabinController?.SetDependencies(this);
        forestController?.SetDependencies(this);
    }

    private void Start()
    {
        cabinTeleportController?.Init();
        respawnController?.Init();
        sanityController?.Init();
        craftingStationController?.Init();
        craftingController?.Init();
        endGameController?.Init();
        pauseWindowController?.Init();
        labyrinthController?.Init();
        ToCabinController?.Init();
        forestController?.Init();
    }
}
