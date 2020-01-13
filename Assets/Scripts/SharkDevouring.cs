using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkDevouring : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameObject mast = GameObject.Find("Mast");
            GameObject rudder = GameObject.Find("Rudder");
            Destroy(mast);
            Destroy(rudder);
        }
    }
}
