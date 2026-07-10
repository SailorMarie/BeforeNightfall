using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameSceneLevelController : LevelController
{
    [SerializeField] Window m_tutoWindow;
    [SerializeField] Transform m_LabyrinthExit;

    private PopUpController m_popUpController;



    public override void Init()
    {
        if (LevelManager.Instance.IsFirstTimeLevelLoaded(SceneManager.GetActiveScene().name))
        {
            m_popUpController.OpenPopUp(m_tutoWindow);
        }
        else
        {
            PlayerManager.Instance.SetPlayerPosition(m_LabyrinthExit,m_LabyrinthExit.rotation);
        }

    }

    public override void SetDependencies(GameController gameController)
    {
     m_popUpController = gameController.popUpController;
    }
}
