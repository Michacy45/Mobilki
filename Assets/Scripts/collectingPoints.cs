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

        
            if (other.gameObject.CompareTag("Pick Up"))
            {
                    other.gameObject.SetActive(false);
                    count++;
                    SetCount();
                
            }
    }

    void SetCount()
    {
        countText.text = "Count: " + count.ToString();
    }
}
