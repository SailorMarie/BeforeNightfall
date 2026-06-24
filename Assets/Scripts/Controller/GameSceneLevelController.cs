using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneLevelController : LevelController
{
    public override void Init()
    {
        if (LevelManager.Instance.IsFirstTimeLevelLoaded(SceneManager.GetActiveScene().name))
        {
            Debug.Log("[LEVEL]FirstTime");
        }

    }

    public override void SetDependencies(GameController gameController)
    {
        
    }
}
