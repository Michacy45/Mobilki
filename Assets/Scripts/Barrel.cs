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

    protected Rigidbody Rb3D;
    public GameObject explosion;
    protected bool isDamageResistant = false;
    public PauseGame pauseGame;

    void Start()
    {
        pauseGame = (PauseGame)GameObject.Find("Canvas").GetComponent(typeof(PauseGame));
        //Physics.IgnoreCollision(GameObject.Find("Deck").GetComponent<Collider>(), GetComponent<Collider>());
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
            //GameObject explosion2 = Instantiate(explosion, transform.position, Quaternion.identity);
            StartCoroutine(Czekanko(other));
           
        }
    }

    IEnumerator Czekanko(Collider other)
    {
        GameObject explosion2 = Instantiate(explosion, transform.position, Quaternion.identity);
        //Destroy(this.gameObject, 0.25f);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        foreach(MeshRenderer meszyk in gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            meszyk.enabled = false;
        }
        Destroy(other.gameObject);
        GameObject mast = GameObject.Find("Mast");
        GameObject rudder = GameObject.Find("Rudder");
        Destroy(mast);
        Destroy(rudder);
        yield return new WaitForSeconds(3);
        pauseGame.Death();
       
    }
}