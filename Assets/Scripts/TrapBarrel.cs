using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBarrel : MonoBehaviour
{
    private bool inTouch;
    private bool finished;
    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        inTouch = false;
        finished = false;
        offset = 2.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (inTouch)
        {
            float diff = 5 * Time.deltaTime;
            gameObject.transform.Translate(new Vector3(0, diff, 0));
            offset -= diff;
            if (offset<=0)
            {
                inTouch = false;
                gameObject.transform.GetChild(0).GetComponent<Barrel>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           // gameObject.transform.GetChild(0).position += new Vector3(0, 2.1f, 0);
           // gameObject.transform.GetChild(0).GetComponent<Barrel>().enabled = true;
            //gameObject.GetComponentsInChildren<Transform>()[0].position += new Vector3(100, 100, 100);
            /*gameObject.transform.position += new Vector3(100, 100, 100);*/
            //other.gameObject.transform.position += new Vector3(0, 0, 0);
            inTouch = true;
            Debug.Log("wykryl");
        }
        
    }
}
