using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject leftButton;
    public GameObject rightButton;
    public Slider mastSlider;
    public GameObject pauseMenu;
    public GameObject endMenu;
    public GameObject deathPanel;
    public GameObject menuButton;

    private ScoreManager script;
    public Text timerText;
    private float startTime;
    private bool isFinished = false;
    private bool saved = false;

    // Start is called before the first frame update
    void Start()
    {
        saved = false;
        Time.timeScale = 1;
        startTime = Time.time;
        timerText.text = startTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFinished == false)
        {
            float t = Time.time - startTime;
            timerText.text = t.ToString("0.00");
        }
        else if(isFinished == true && saved == false)
        {
            saved = true;
            Debug.Log("eloo");
            ScoreManager.addScore(Time.time - startTime);
        }

        if(collectingPoints.count == 4)
        {
            isFinished = true;
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
        menuButton.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        leftButton.SetActive(true);
        rightButton.SetActive(true);
        mastSlider.interactable = true;
        menuButton.SetActive(true);
    }

    public void Death()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0;
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        mastSlider.interactable = false;
        menuButton.SetActive(false);
        
    }
}
