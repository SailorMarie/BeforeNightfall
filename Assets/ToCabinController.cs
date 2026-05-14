using System;
using UnityEngine;

public class ToCabinController : MonoBehaviour
{
    public Action OnCabinReached;
    private const string CABIN_SCENE = "Cabin";
    [SerializeField] private CabinTrigger m_cabinTrigger;

    public void SetDependencies(GameController gameController)
    {

    }

    public void Init()
    {
        OnCabinReached += GoToCabin;
        m_cabinTrigger.Initialize(this);
    }

    private void GoToCabin()
    {
        SceneLoaderManager.Instance.LoadScene(CABIN_SCENE);
    }
}
