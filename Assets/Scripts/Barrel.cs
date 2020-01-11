using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Barrel : MonoBehaviour
{
//    public float degreesPerSecond = 15.0f;
    private float amplitude = 0.2f;
    private float frequency = 0.8f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    public GameObject pauseMenu;
    public GameObject resumeButton;

    private  Rigidbody Rb3D;
    public GameObject explosion;
    protected bool isDamageResistant = false;

    void Start()
    {
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
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject explosion2 = Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(this.gameObject, 0.25f);
            Destroy(other.gameObject);
            GameObject mast = GameObject.FindGameObjectWithTag("Mast");
            GameObject rudder = GameObject.FindGameObjectWithTag("Rudder");
            Destroy(mast);
            Destroy(rudder);
            pauseMenu.SetActive(true);
            resumeButton.SetActive(false);
        }
    }

    public void mainMenu()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        SceneManager.LoadScene("Menu");

    }


}