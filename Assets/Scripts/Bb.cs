using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bb : MonoBehaviour
{
    public float force = 400;
    private Rigidbody rb;
    private Vector3 wind;
    // Start is called before the first frame update
    private void Awake()
    {
        wind = Vector3.zero;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeWind();
        rb.velocity = wind * Time.deltaTime * force;
    }

    private void ChangeWind()
    {
        wind.x -= ChangeWindCoordinate(wind.x);
        wind.z -= ChangeWindCoordinate(wind.z);
    }

    private float ChangeWindCoordinate(float coordinate)
    {
        if (Mathf.Abs(coordinate) > 2.0f)
        {
            return Random.Range(0.0f, 1.0f / Mathf.Pow(coordinate, 3.0f));
        }
        else
        {
            return Random.Range(-0.5f, 0.5f);
        }
    }

}
