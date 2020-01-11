using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject leftButton;
    public GameObject rightButton;
    public Slider mastSlider;
    public GameObject pauseMenu;
    public GameObject endMenu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(collectingPoints.count == 4)
        {
            Time.timeScale = 0;
            leftButton.SetActive(false);
            rightButton.SetActive(false);
            mastSlider.interactable = false;
            endMenu.SetActive(true);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        mastSlider.interactable = false;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        leftButton.SetActive(true);
        rightButton.SetActive(true);
        mastSlider.interactable = true;
    }

    public void newGame()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        SceneManager.LoadScene("Game");
    }
}
