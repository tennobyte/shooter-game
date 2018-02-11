using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public Slider loadingSlider;
    public GameObject loadingScreen;
    public GameObject mainMenu;

    public void LoadLevel(string sceneName)
    {
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelAsync(sceneName));
    }

    IEnumerator LoadLevelAsync(string sceneName)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName);
        while (!loading.isDone)
        {
            float loadingProgress = Mathf.Clamp01(loading.progress / .9f);
            loadingSlider.value = loadingProgress;
            yield return null;
        }
    }

}
