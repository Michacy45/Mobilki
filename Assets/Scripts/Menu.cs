using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject loadingScreenController;
    public GameObject stere;
    public Slider slider;
    public float oldValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        SceneManager.LoadScene("Game");
        /*Debug.Log(GameObject.Find("LoadingSlider").GetComponent<Slider>().value);
        slider = GameObject.Find("LoadingSlider").GetComponent<Slider>();
        stere = GameObject.Find("Handle");
        StartCoroutine(LoadAsyncrhonously(1));*/
    }

    public void ExitGame()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        Application.Quit();
    }
    public void MainMenu()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        SceneManager.LoadScene("Menu");
    }

    public void Scores()
    {
        Time.timeScale = 1;
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        SceneManager.LoadScene("Scores");
    }

    IEnumerator LoadAsyncrhonously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        //mainMenuController.SetActive(false);
        //loadingScreenController.SetActive(true);
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
