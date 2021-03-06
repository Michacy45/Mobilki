﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudderControll : MonoBehaviour
{
    private int direction;
    private float widthScreen;
    private float heightScreen;
    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
        widthScreen = Screen.width;
        heightScreen = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            direction = -1;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            direction = 1;
        }
        else
        {
            direction = 0;
        }
        transform.Rotate(0, Time.deltaTime * 100 * direction, 0);
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > widthScreen/2 && Input.GetTouch(i).position.y > heightScreen/4)
            {
                direction = -1;
            }
            else if (Input.GetTouch(i).position.x < widthScreen / 2 && Input.GetTouch(i).position.y > heightScreen / 4)
            {
                direction = 1;
            }
            else
            {
                direction = 0;
            }
            transform.Rotate(0, Time.deltaTime * 100 * direction, 0);
            i++;
        }
    }
}
