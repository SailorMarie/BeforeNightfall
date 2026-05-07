using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController: MonoBehaviour
{
    private const string GAME_SCENE = "Game";
    public void LoadGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }
}
