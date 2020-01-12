using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boat2 : MonoBehaviour
{
    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        float deckRot = gameObject.transform.Find("Deck").eulerAngles.y;
        float shipRot = transform.eulerAngles.y;
        gameObject.transform.Find("Deck").Rotate(0.0f, shipRot - deckRot, 0.0f);

        transform.Rotate(0.0f, deckRot - shipRot, 0.0f);

        
        //gameObject.transform.Find("deck").Translate(speed * Input.GetAxis("Vertical") * Time.deltaTime * -1, 0f, speed * Input.GetAxis("Horizontal") * Time.deltaTime);
        //transform.Translate(speed * Input.GetAxis("Vertical") * Time.deltaTime * -1, 0f, speed * Input.GetAxis("Horizontal") * Time.deltaTime);
    }
}
