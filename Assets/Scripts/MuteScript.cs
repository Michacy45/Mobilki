using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject muteButton;
    public GameObject unMuteButton;
    public AudioListener audioListener;
    void Start()
    {
        if (PlayerPrefs.GetInt("mute") == 1)
        {
            //audioListener.enabled = false;
            unMuteButton.SetActive(true);
            AudioListener.pause = true;
            muteButton.SetActive(false);
        }
        else
        {
            AudioListener.pause = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Mute()
    {
        PlayerPrefs.SetInt("mute", 1);
        muteButton.SetActive(false);
        unMuteButton.SetActive(true);
        AudioListener.pause = true;
        //audioListener.enabled = false;
    }
    public void UnMute()
    {
        PlayerPrefs.SetInt("mute", 0);
        muteButton.SetActive(true);
        unMuteButton.SetActive(false);
        AudioListener.pause = false;
        //audioListener.enabled = true;
    }
}
