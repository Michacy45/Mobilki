using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBarrel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponentInChildren<Transform>().position += new Vector3(0.0f, 10, 0);
            //gameObject.transform.position += new Vector3(0.0f, 0.0f, 10);
            Debug.Log("wykryl");
        }
        
    }
}
