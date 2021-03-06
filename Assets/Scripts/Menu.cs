﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

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
}
