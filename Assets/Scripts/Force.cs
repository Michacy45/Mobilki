using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{

    public GameObject windObject;
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(windObject.transform.forward * 30);
    }
}
