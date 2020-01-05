using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject mastSlider;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        mastSlider.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        leftButton.SetActive(true);
        rightButton.SetActive(true);
        mastSlider.SetActive(true);
    }
}
