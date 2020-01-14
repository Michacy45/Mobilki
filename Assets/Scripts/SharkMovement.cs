using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    private float letterCenterX;
    private float letterCenterY;
    private float letterCenterZ;
    public PauseGame pauseGame;
    void Start()
    {
        pauseGame = (PauseGame)GameObject.Find("Canvas").GetComponent(typeof(PauseGame));
        letterCenterX = GameObject.FindGameObjectWithTag("A").transform.position.x;
        letterCenterY = GameObject.FindGameObjectWithTag("A").transform.position.y;
        letterCenterZ = GameObject.FindGameObjectWithTag("A").transform.position.z;

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
        transform.RotateAround(new Vector3(letterCenterX, letterCenterY, letterCenterZ), -Vector3.up, 30 * Time.deltaTime);
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
            pauseGame.Death();
        }
    }

}
