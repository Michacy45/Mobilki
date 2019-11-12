using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastControll2 : MonoBehaviour
{

    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = -1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = 1;
        }
        else
        {
            direction = 0;
        }

        transform.Rotate(0, Time.deltaTime * 100 * direction, 0);
    }

  /*  private float maxAngleRotation()
    {
        float angle = Time.deltaTime * 100 * direction;
        float deckAngleY = this.transform.parent.rotation.eulerAngles.y;
        float tempAngle = this.transform.rotation.eulerAngles.y;

        float dif = deckAngleY - tempAngle;
         if ((dif > -270 && dif<-180) || (dif >90 && dif < 180))
         {

            if (angle < 0)
            {
                return 0;
            }
            else
            {
                return angle;
            }
         }
         else if ((dif > 180 && dif < 270) || (dif > -180 && dif < -90))
         {
            if (angle > 0)
            {
                return 0;
            }
            else
            {
                return angle;
            }
         }
         else
         {
             return angle;
         }

    }*/
}