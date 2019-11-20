using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MastControll2 : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float currentAngle = GameObject.Find("Mast").GetComponent<HingeJoint>().angle;
        float sliderAngle = GameObject.Find("MastSlider").GetComponent<Slider>().value;
        float differenceAngle = sliderAngle - currentAngle;
    
        transform.Rotate(0, Time.deltaTime * differenceAngle * 3, 0);
    }

}