using UnityEngine;


public class MainMenu : MonoBehaviour {

    private string sceneName = "InfiniteLevel";

    public LevelLoader levelLoader;

    public GameObject optionsMenu;
    public GameObject mainMenu;

    public void PlayGame()
    {
        levelLoader.LoadLevel(sceneName);
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseOptions()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
