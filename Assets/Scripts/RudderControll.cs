using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudderControll : MonoBehaviour
{
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
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
    }
}
