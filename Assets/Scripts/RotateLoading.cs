using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RotateLoading : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject stere;
    private float oldValue;
    void Start()
    {
        oldValue = 0.0f;
    }

    // Update is called once per frame
    public void RotateStere()
    {
        
        float sliderValue = GameObject.Find("LoadingSlider").GetComponent<Slider>().value;
        Debug.Log(sliderValue);
        stere.transform.Rotate(new Vector3(0.0f,0.0f ,(sliderValue - oldValue) * 2 * Mathf.PI));
        oldValue = sliderValue;
    }
}
