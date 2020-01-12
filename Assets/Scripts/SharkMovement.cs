using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    private float angle;
    public float speed;
    public float radius;
    private float centerX;
    private float centerZ;
    void Start()
    {
        angle = 0;
        speed = (2 * Mathf.PI) / 5;
        radius = 15;
        centerX = GameObject.FindGameObjectWithTag("A").transform.position.x;
        centerZ = GameObject.FindGameObjectWithTag("A").transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        float x, z, tmpAngle;
        /* tmpAngle = angle;
         angle += speed * Time.deltaTime;
         print(angle);
         x = Mathf.Cos(angle) * radius + centerX;
         z = Mathf.Sin(angle) * radius + centerZ;
         transform.position = new Vector3(x, transform.position.y, z);*/
        transform.RotateAround(GameObject.FindGameObjectWithTag("A"). transform.position, -Vector3.up, 30 * Time.deltaTime);
    }
}
