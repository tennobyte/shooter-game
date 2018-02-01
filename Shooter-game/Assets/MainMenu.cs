using UnityEngine;


public class MainMenu : MonoBehaviour {

    private int levelIndex = 1;

    public GameObject levelLoader;

    public void PlayGame()
    {
        levelLoader.GetComponent<LevelLoader>().LoadLevel(levelIndex);
        //StartCoroutine(LoadLevel(levelIndex));
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
