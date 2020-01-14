using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public PauseGame pauseGame;
    void Start()
    {
        //Physics.IgnoreCollision(rocks.GetComponentInChildren<Collider>(), GetComponent<Collider>());
        /*Rigidbody[] rigidBodies = rocks.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rigidbody in rigidBodies)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }*/
        pauseGame = (PauseGame)GameObject.Find("Canvas").GetComponent(typeof(PauseGame));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            //Destroy(this.gameObject, 0.25f);
            Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            GameObject mast = GameObject.Find("Mast");
            GameObject rudder = GameObject.Find("Rudder");
            /*mast.SetActive(false);
            rudder.SetActive(false);*/
            pauseGame.Death();
            Destroy(mast);
            Destroy(rudder);
        }
    }
}