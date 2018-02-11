using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused;
    public string mainMenuSceneName = "MainMenu";

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject gameOverMenu;
    public GameObject score;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.isGameOver)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
	}

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OpenOptions()
    {
        //Debug.Log("options");
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void OpenMainMenu()
    {
        //Debug.Log("menu");
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void CloseOptions()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ExitGame()
    {
        //Debug.Log("exit");
        Application.Quit();
    }

    public void OpenGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        score.GetComponent<TextMeshProUGUI>().text = "YOUR POINTS: " + GameManager.instance.getPoints().ToString();
    }
}
