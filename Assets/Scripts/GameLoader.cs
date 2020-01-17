using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject loadingScreenController;
    public GameObject mainMenuController;
    public GameObject stere;
    public Slider slider;
    public float oldValue;
    public void loadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsyncrhonously(sceneIndex));
    }

    IEnumerator LoadAsyncrhonously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        mainMenuController.SetActive(false);
        loadingScreenController.SetActive(true);
        oldValue = slider.value;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            stere.transform.Rotate(0.0f, 0.0f, (slider.value - oldValue) * 360);
            yield return null;
        }
    }
}
