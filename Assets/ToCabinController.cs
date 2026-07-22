using System;
using UnityEngine;

public class ToCabinController : MonoBehaviour
{
    public Action OnCabinReached;
    private const string CABIN_SCENE = "Cabin";
    [SerializeField] private CabinTrigger m_cabinTrigger;
    [SerializeField] private InteractibleSkull m_interactibleSkull;

    public void SetDependencies(GameController gameController)
    {

    }

    public void Init()
    {
        OnCabinReached += GoToCabin;
        m_cabinTrigger.Initialize(this);
        m_interactibleSkull.Init(this);
        m_interactibleSkull.OnUnlockDoor += UnlockDoor;
    }

    private void UnlockDoor()
    {
        m_cabinTrigger.EnableTrigger();
    }

    private void GoToCabin()
    {
        SceneLoaderManager.Instance.LoadAndAddSceneToLevelManager(CABIN_SCENE);
    }
}
