using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCollision : MonoBehaviour
{
    public GameObject rocks;
    // Start is called before the first frame update
    void Start()
    {
        //Physics.IgnoreCollision(rocks.GetComponentInChildren<Collider>(), GetComponent<Collider>());
        Rigidbody[] rigidBodies = rocks.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rigidbody in rigidBodies)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}