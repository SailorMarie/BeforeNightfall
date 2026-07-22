using System;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
    public Action OnEndGameReach;
    private const string END_GAME_SCENE = "GameOverScene";
    [SerializeField] private EndSceneTrigger m_endSceneTrigger;

    public void SetDependencies(GameController gameController)
    {
        
    }

    public void Init()
    {
        OnEndGameReach += EndGame;
        m_endSceneTrigger.Initialize(this);
    }

    private void EndGame()
    {
        SceneLoaderManager.Instance.LoadAndAddSceneToLevelManager(END_GAME_SCENE);
    }
}
