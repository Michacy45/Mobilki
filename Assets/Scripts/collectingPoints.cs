using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class collectingPoints : MonoBehaviour
{
    public static int count;
    public Image sg;
    public Image ag;
    public Image ig;
    public Image lg;
    public Image sy;
    public Image ay;
    public Image iy;
    public Image ly;
    public Text timeText;
    private float gameTime;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        gameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        timeText.text = "Your time: " + gameTime.ToString("0.00");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("A"))
        {
            other.gameObject.SetActive(false);
            ag.gameObject.SetActive(false);
            ay.gameObject.SetActive(true);
            count += 1;
        }
        else if (other.gameObject.CompareTag("S"))
        {
            other.gameObject.SetActive(false);
            sg.gameObject.SetActive(false);
            sy.gameObject.SetActive(true);
            count += 1;

        }
        else if (other.gameObject.CompareTag("I"))
        {
            other.gameObject.SetActive(false);
            ig.gameObject.SetActive(false);
            iy.gameObject.SetActive(true);
            count += 1;

        }
        else if (other.gameObject.CompareTag("L"))
        {
            other.gameObject.SetActive(false);
            lg.gameObject.SetActive(false);
            ly.gameObject.SetActive(true);
            count += 1;

        }
    }

}
