using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class collectingPoints : MonoBehaviour
{
    private int count;
    public Text countText;
    public GameObject player;
    private Wind wind;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCount();
        wind = player.GetComponent<Wind>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log(wind.currentSpeed);

        
            if (other.gameObject.CompareTag("Pick Up"))
            {
                if (Mathf.Abs(wind.currentSpeed) < 0.03f)
                {
                    other.gameObject.SetActive(false);
                    count++;
                    SetCount();
                }
            }
    }

    void SetCount()
    {
        countText.text = "Count: " + count.ToString();
    }
}
