using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boat : MonoBehaviour
{
    public float speed;
    public Text countText;

    private GameObject player;
    private Rigidbody rigidbody;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        count = 0;
        SetCount();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed*Input.GetAxis("Vertical") * Time.deltaTime*-1, 0f, speed* Input.GetAxis("Horizontal") * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCount();
        }
    }

    void SetCount()
    {
        countText.text = "Count: " + count.ToString();
    }
}
