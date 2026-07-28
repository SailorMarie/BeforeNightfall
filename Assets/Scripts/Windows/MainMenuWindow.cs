using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuWindow : Window
{
    
    private const string FIRST_SCENE_NAME = "First_Scene";
   public void OnPlayButtonPressed()
    {
        SceneLoaderManager.Instance.LoadScene(FIRST_SCENE_NAME);
        Close();
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
