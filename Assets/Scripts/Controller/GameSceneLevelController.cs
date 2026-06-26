using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameSceneLevelController : LevelController
{
    [SerializeField] Window m_tutoWindow;

    private PopUpController m_popUpController;



    public override void Init()
    {
        if (LevelManager.Instance.IsFirstTimeLevelLoaded(SceneManager.GetActiveScene().name))
        {
            m_popUpController.OpenPopUp(m_tutoWindow);
        }

    }

    public override void SetDependencies(GameController gameController)
    {
     m_popUpController = gameController.popUpController;
    }
}
