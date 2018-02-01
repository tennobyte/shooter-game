using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public Slider loadingSlider;
    public GameObject loadingScreen;
    public GameObject mainMenu;

    public void LoadLevel(int sceneIndex)
    {
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelAsync(sceneIndex));
    }

    IEnumerator LoadLevelAsync(int sceneIndex)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneIndex);
        while (!loading.isDone)
        {
            float loadingProgress = Mathf.Clamp01(loading.progress / .9f);
            loadingSlider.value = loadingProgress;
            yield return null;
        }
    }

}
