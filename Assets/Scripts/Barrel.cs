using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
//    public float degreesPerSecond = 15.0f;
    private float amplitude = 0.2f;
    private float frequency = 0.8f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    public GameObject Player;
    protected Rigidbody Rb3D;
    public GameObject explosion;
    protected bool isDamageResistant = false;

    protected virtual void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Rb3D = GetComponent<Rigidbody>();
        posOffset = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        //transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            Debug.Log("test");
            GameObject explosion2 = Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(this.gameObject, 0.25f);
            Destroy(explosion,1.5f);
            Destroy(other);
        }
    }
}